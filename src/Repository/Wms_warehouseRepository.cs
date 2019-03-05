using YL.Core.Entity;
using IRepository;
using SqlSugar;

namespace Repository
{
    public class Wms_warehouseRepository : BaseRepository<Wms_warehouse>, IWms_warehouseRepository
    {
        public Wms_warehouseRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}