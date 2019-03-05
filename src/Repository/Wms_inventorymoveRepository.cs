using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_inventorymoveRepository : BaseRepository<Wms_inventorymove>, IWms_inventorymoveRepository
    {
        public Wms_inventorymoveRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}