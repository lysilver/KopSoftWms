using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_CustomerRepository : BaseRepository<Wms_Customer>, IWms_CustomerRepository
    {
        public Wms_CustomerRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}