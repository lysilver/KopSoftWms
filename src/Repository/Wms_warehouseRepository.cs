using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_warehouseRepository : BaseRepository<Wms_warehouse>, IWms_warehouseRepository
    {
        public Wms_warehouseRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}