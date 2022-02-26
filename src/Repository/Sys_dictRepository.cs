using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Sys_dictRepository : BaseRepository<Sys_dict>, ISys_dictRepository
    {
        public Sys_dictRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}