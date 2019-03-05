using YL.Core.Entity;
using IRepository;
using SqlSugar;

namespace Repository
{
    public class Wms_CarrierRepository : BaseRepository<Wms_Carrier>, IWms_CarrierRepository
    {
        public Wms_CarrierRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}
