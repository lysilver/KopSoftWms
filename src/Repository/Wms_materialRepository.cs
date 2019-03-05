using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_materialRepository : BaseRepository<Wms_material>, IWms_materialRepository
    {
        public Wms_materialRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}