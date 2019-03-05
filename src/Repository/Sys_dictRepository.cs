using YL.Core.Entity;
using IRepository;
using SqlSugar;

namespace Repository
{
    public class Sys_dictRepository : BaseRepository<Sys_dict>, ISys_dictRepository
    {
        public Sys_dictRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}