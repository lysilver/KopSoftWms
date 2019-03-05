using YL.Core.Entity;
using YL.Core.Dto;

namespace IServices
{
    public interface ISys_dictServices : IBaseServices<Sys_dict>
    {
        string PageList(PubParams.DictBootstrapParams bootstrap);
    }
}