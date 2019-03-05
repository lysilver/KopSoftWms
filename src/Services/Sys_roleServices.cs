using IRepository;
using IServices;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace Services
{
    public class Sys_roleServices : BaseServices<Sys_role>, ISys_roleServices
    {
        private readonly ISys_roleRepository _repository;
        private readonly ISys_rolemenuServices _rolemenuServices;
        private readonly ISys_menuServices _menuServices;
        private readonly SqlSugarClient _client;

        public Sys_roleServices(ISys_menuServices menuServices, ISys_rolemenuServices rolemenuServices, SqlSugarClient client, ISys_roleRepository repository) : base(repository)
        {
            _repository = repository;
            _client = client;
            _rolemenuServices = rolemenuServices;
            _menuServices = menuServices;
        }

        public string PageList(Bootstrap.BootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Sys_role, Sys_user, Sys_user>
                ((s, c, u) => new object[] {
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId
                 })
                 .Select((s, c, u) => new
                 {
                     RoleId = s.RoleId.ToString(),
                     s.RoleType,
                     s.RoleName,
                     s.IsDel,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable().Where((s) => s.IsDel == 1);
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.RoleName.Contains(bootstrap.search));
            }
            if (!bootstrap.datemin.IsEmpty() && !bootstrap.datemax.IsEmpty())
            {
                query.Where(s => s.CreateDate > bootstrap.datemin.ToDateTimeB() && s.CreateDate <= bootstrap.datemax.ToDateTimeE());
            }
            if (bootstrap.order.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                query.OrderBy($"MergeTable.{bootstrap.sort} desc");
            }
            else
            {
                query.OrderBy($"MergeTable.{bootstrap.sort} asc");
            }
            var list = query.ToPageList(bootstrap.offset, bootstrap.limit, ref totalNumber);
            return Bootstrap.GridData(list, totalNumber).JilToJson();
        }

        public List<PermissionMenu> GetMenu()
        {
            var permissionMenus = _menuServices.QueryableToList(c => c.IsDel == 1 && c.MenuType == "menu" && c.Status == 1);
            var parentPermissions = permissionMenus.Where(a => a.MenuParent == -1).ToList();
            var ret = new List<PermissionMenu>();
            parentPermissions.ForEach(p =>
            {
                PermissionMenu permissionMenu = PermissionMenu.Create(p);
                permissionMenu.Children = permissionMenus
                .Where(c => c.MenuParent == p.MenuId)
                .Select(m => new PermissionMenu()
                {
                    Id = m.MenuId.ToString(),
                    Name = m.MenuName,
                    Icon = m.MenuIcon,
                    Url = m.MenuUrl,
                    ParentId = m.MenuParent.ToString()
                }).ToList();
                ret.Add(permissionMenu);
            });
            return ret;
        }

        public List<PermissionMenu> GetMenu(long roleId, string menuType = "menu")
        {
            var listAll = _client.Queryable<Sys_rolemenu, Sys_menu>
                ((s, c) => new object[] {
                   JoinType.Left,s.MenuId==c.MenuId,
                 })
                 .Select((s, c) => new
                 {
                     RoleId = s.RoleId.ToString(),
                     c.IsDel,
                     c.MenuName,
                     c.MenuUrl,
                     c.MenuType,
                     c.MenuIcon,
                     c.MenuParent,
                     c.Status,
                     c.MenuId,
                     c.Sort
                 }).MergeTable().Where((s) => s.IsDel == 1 && s.MenuType == menuType && s.Status == 1 && s.RoleId == roleId.ToString()).OrderBy(s => s.Sort).ToList();
            var listParent = listAll.Where(s => s.MenuParent == -1).ToList();
            List<PermissionMenu> ret = new List<PermissionMenu>();
            listParent.ForEach(p =>
            {
                PermissionMenu permissionMenu = PermissionMenu.Create(new Sys_menu
                {
                    MenuId = p.MenuId,
                    Status = p.Status,
                    MenuIcon = p.MenuIcon,
                    MenuName = p.MenuName,
                    MenuParent = p.MenuParent,
                    MenuType = p.MenuType,
                    MenuUrl = p.MenuUrl,
                });
                permissionMenu.Children = listAll
                .Where(c => c.MenuParent == p.MenuId)
                .Select(m => new PermissionMenu()
                {
                    Id = m.MenuId.ToString(),
                    Name = m.MenuName,
                    Icon = m.MenuIcon,
                    Url = m.MenuUrl,
                    ParentId = m.MenuParent.ToString()
                }).ToList();
                ret.Add(permissionMenu);
            });
            return ret;
        }

        public DbResult<bool> Insert(Sys_role role, long userId, string[] menuId)
        {
            return _client.Ado.UseTran(() =>
           {
               role.RoleId = PubId.SnowflakeId;
               role.CreateBy = userId;
               role.RoleType = "#";
               var roleId = _repository.InsertReturnEntity(role);
               if (!roleId.IsNullT())
               {
                   var list = new List<Sys_rolemenu>();
                   foreach (var item in menuId)
                   {
                       list.Add(new Sys_rolemenu
                       {
                           CreateBy = userId,
                           MenuId = item.ToInt64(),
                           RoleId = roleId.RoleId,
                           RoleMenuId = PubId.SnowflakeId
                       });
                   }
                   _rolemenuServices.Insert(list);
               }
           });
        }

        public DbResult<bool> Update(Sys_role role, long userId, string[] menuId)
        {
            var list = _rolemenuServices.QueryableToList(c => c.RoleId == role.RoleId);
            string idsu = "";  //数据库中的Id;
            list.ForEach((m) =>
            {
                idsu += m.MenuId + ",";
            });
            var arr = idsu.TrimEnd(',').ToSplit(',');
            //menuId 页面上的菜单Id;
            role.ModifiedBy = userId;
            role.ModifiedDate = DateTimeExt.DateTime;
            //role.RoleType = "#";
            string[] pageId = arr.Union(menuId).Except(menuId).ToArray(); //delete
            string[] dataId = menuId.Union(arr).Except(arr).ToArray();  //insert
            return _repository.UseTran(() =>
            {
                _repository.Update(role);
                List<long> array = new List<long>();
                if (pageId.Any())
                {
                    foreach (var item in pageId)
                    {
                        array.Add(list.Where(c => c.RoleId == role.RoleId && c.MenuId == item.ToInt64()).SingleOrDefault().RoleMenuId);
                    }
                    _rolemenuServices.Delete(array.ToArray());
                }
                if (dataId.Any())
                {
                    var roleList = new List<Sys_rolemenu>();
                    foreach (var item in dataId)
                    {
                        roleList.Add(new Sys_rolemenu
                        {
                            CreateBy = userId,
                            MenuId = item.ToInt64(),
                            RoleId = role.RoleId,
                            RoleMenuId = PubId.SnowflakeId
                        });
                    }
                    _rolemenuServices.Insert(roleList);
                }
            });

            //if (arr.Count() > menuId.Count())
            //{
            //    //数据库中的数量大于页面传过来的数量就删除
            //    string[] except;
            //    if (menuId.Count() > arr.Count())
            //    {
            //        except = menuId.Except(arr).ToArray();
            //    }
            //    else
            //    {
            //        except = arr.Except(menuId).ToArray();
            //    }
            //    List<long> array = new List<long>();
            //    if (except.Any())
            //    {
            //        foreach (var item in except)
            //        {
            //            array.Add(list.Where(c => c.RoleId == role.RoleId && c.MenuId == item.ToInt64()).SingleOrDefault().RoleMenuId);
            //        }
            //    }
            //    return _repository.UseTran(() =>
            //     {
            //         _repository.Update(role);
            //         _rolemenuServices.Delete(array.ToArray());
            //     });
            //}
            //else
            //{
            //    //update/add
            //    return _repository.UseTran(() =>
            //    {
            //        _repository.Update(role);
            //        foreach (var item in menuId)
            //        {
            //            var model = _rolemenuServices.QueryableToEntity(c => c.RoleId == role.RoleId && c.MenuId == item.ToInt64());
            //            if (model.IsNullT())
            //            {
            //                //add
            //                _rolemenuServices.Insert(new Sys_rolemenu
            //                {
            //                    CreateBy = userId,
            //                    MenuId = item.ToInt64(),
            //                    RoleId = role.RoleId,
            //                    RoleMenuId = PubId.SnowflakeId
            //                });
            //            }
            //            else
            //            {
            //                //update
            //                model.ModifiedBy = userId;
            //                model.ModifiedDate = DateTimeExt.DateTime;
            //                _rolemenuServices.UpdateEntity(model);
            //            }
            //        }
            //    });
            //}
        }
    }
}