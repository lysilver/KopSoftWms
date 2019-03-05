using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Wms_reservoirareaRepository : BaseRepository<Wms_reservoirarea>, IWms_reservoirareaRepository
    {
        public Wms_reservoirareaRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}