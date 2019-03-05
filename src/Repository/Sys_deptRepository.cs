using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Sys_deptRepository : BaseRepository<Sys_dept>, ISys_deptRepository
    {
        public Sys_deptRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}