using YL.Core.Entity;
using IRepository;
using SqlSugar;

namespace Repository
{
    public class Wms_CustomerRepository : BaseRepository<Wms_Customer>, IWms_CustomerRepository
    {
        public Wms_CustomerRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}
