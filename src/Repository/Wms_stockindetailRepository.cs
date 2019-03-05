using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_stockindetailRepository : BaseRepository<Wms_stockindetail>, IWms_stockindetailRepository
    {
        public Wms_stockindetailRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}