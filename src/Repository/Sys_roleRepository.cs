using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Sys_roleRepository : BaseRepository<Sys_role>, ISys_roleRepository
    {
        public Sys_roleRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}