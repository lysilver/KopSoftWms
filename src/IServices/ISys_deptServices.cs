using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface ISys_deptServices : IBaseServices<Sys_dept>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);
    }
}