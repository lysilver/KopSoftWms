using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_inventoryrecordRepository : BaseRepository<Wms_inventoryrecord>, IWms_inventoryrecordRepository
    {
        public Wms_inventoryrecordRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}