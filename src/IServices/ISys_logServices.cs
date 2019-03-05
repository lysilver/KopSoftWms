using YL.Core.Entity;
using YL.Utils.Table;

namespace IServices
{
    public interface ISys_logServices : IBaseServices<Sys_log>
    {
        string PageList(Bootstrap.BootstrapParams bootstrap);

        string EChart(Bootstrap.BootstrapParams bootstrap);
    }
}