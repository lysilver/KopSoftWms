using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Sys_rolemenuRepository : BaseRepository<Sys_rolemenu>, ISys_rolemenuRepository
    {
        public Sys_rolemenuRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}