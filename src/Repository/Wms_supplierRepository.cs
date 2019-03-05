using YL.Core.Entity;
using IRepository;
using SqlSugar;

namespace Repository
{
    public class Wms_supplierRepository : BaseRepository<Wms_supplier>, IWms_supplierRepository
    {
        public Wms_supplierRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}
