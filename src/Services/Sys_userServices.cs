using IRepository;
using IServices;
using SqlSugar;
using System;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Utils.Security;
using YL.Utils.Table;

namespace Services
{
    public class Sys_userServices : BaseServices<Sys_user>, ISys_userServices
    {
        private readonly SqlSugarClient _client;
        private readonly ISys_userRepository _UserRepository;

        public Sys_userServices(SqlSugarClient client, ISys_userRepository repository) : base(repository)
        {
            _client = client;
            _UserRepository = repository;
        }

        public (bool, string, SysUserDto) CheckLogin(SysUserDto dto)
        {
            var flag = true;
            if (dto.IsNullT())
            {
                flag = false;
                return (flag, PubConst.Login2, null);
            }
            var sys = _UserRepository.QueryableToEntity(c => c.UserNickname == dto.UserNickname && c.Pwd == dto.Pwd.ToMd5());
            if (sys.IsNullT())
            {
                flag = false;
                return (flag, PubConst.Login2, null);
            }
            if (sys.IsEabled == 0)
            {
                flag = false;
                return (flag, PubConst.Login3, null);
            }

            return (flag, PubConst.Login1, new SysUserDto
            {
                UserId = sys.UserId,
                UserName = sys.UserName,
                UserNickname = sys.UserNickname,
                RoleId = sys.RoleId,
                HeadImg = sys.HeadImg
            });
        }

        public string PageList(Bootstrap.BootstrapParams bootstrap)
        {
            var totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            //var order = ExpressionExt.InitO<Sys_user>(bootstrap.sort);

            var query = _client.Queryable<Sys_user, Sys_user, Sys_user, Sys_dept, Sys_role>
                ((s, c, u, d, r) => new object[] {
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId,
                   JoinType.Left,s.DeptId==d.DeptId,
                   JoinType.Left,s.RoleId==r.RoleId
                 }).Where((s, c, u, d, r) => s.IsDel == 1 && d.IsDel == 1 && r.IsDel == 1)
                 .Select((s, c, u, d, r) => new
                 {
                     UserId = s.UserId.ToString(),
                     s.UserName,
                     s.UserNickname,
                     d.DeptName,
                     r.RoleName,
                     s.Tel,
                     s.Email,
                     s.Sex,
                     s.IsEabled,
                     s.Remark,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.UserName == bootstrap.search || s.UserNickname == bootstrap.search);
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

            //var list = _client.Queryable("Sys_User", "s")
            //   .AddJoinInfo("Sys_User", "c", "s.CreateBy=c.UserId")
            //   .AddJoinInfo("Sys_User", "u", "s.ModifiedBy=u.UserId");
            //if (!bootstrap.search.IsEmpty())
            //{
            //    list.Where("s.IsDel=@id and s.UserName=@UserName or s.UserNickname=@UserName")
            //    .AddParameters(new { id = 1, UserName = bootstrap.search });
            //}
            //else
            //{
            //    list.Where("s.IsDel=@id ")
            //   .AddParameters(new { id = 1 });
            //}
            //if (bootstrap.offset != 0)
            //{
            //    bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            //}
            //list.OrderBy($"s.{bootstrap.sort}")
            //.Select("s.*,c.UserNickname AS CNAME,u.UserNickname AS UNAME")
            //.ToPageList(bootstrap.offset, bootstrap.limit, ref totalNumber);
            return Bootstrap.GridData(list, totalNumber).JilToJson();
        }

        public void Login(long userId, string ip)
        {
            var op = _client.Updateable(new Sys_user { UserId = userId, LoginDate = DateTimeExt.DateTime, LoginIp = ip }).UpdateColumns(d => new { d.LoginIp, d.LoginDate, d.LoginTime }).ReSetValue(c => c.LoginTime == c.LoginTime + 1).ExecuteCommand();
        }
    }
}