using IRepository;
using SqlSugar;
using YL.Core.Entity;

namespace Repository
{
    public class Sys_userRepository : BaseRepository<Sys_user>, ISys_userRepository
    {
        public Sys_userRepository(SqlSugarClient dbContext) : base(dbContext)
        {
        }
    }
}