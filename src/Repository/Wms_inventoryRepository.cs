using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_inventoryRepository : BaseRepository<Wms_inventory>, IWms_inventoryRepository
    {
        public Wms_inventoryRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}