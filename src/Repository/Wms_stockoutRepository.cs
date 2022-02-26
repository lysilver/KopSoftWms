using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_stockoutRepository : BaseRepository<Wms_stockout>, IWms_stockoutRepository
    {
        public Wms_stockoutRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}