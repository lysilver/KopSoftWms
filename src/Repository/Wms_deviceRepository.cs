using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_deviceRepository : BaseRepository<Wms_device>, IWms_deviceRepository
    {
        public Wms_deviceRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}