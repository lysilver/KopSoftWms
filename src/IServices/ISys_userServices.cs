using System.Collections.Generic;
using YL.Core.Dto;
using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface ISys_userServices : IBaseServices<Sys_user>
    {
        (bool, string, SysUserDto) CheckLogin(SysUserDto dto);

        string PageList(Bootstrap.BootstrapParams bootstrap);

        void Login(long userId, string ip);
    }
}