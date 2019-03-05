using IRepository;
using IServices;

using YL.Core.Entity;

namespace Services
{
    public class Sys_rolemenuServices : BaseServices<Sys_rolemenu>, ISys_rolemenuServices
    {
        private readonly ISys_rolemenuRepository _repository;

        public Sys_rolemenuServices(ISys_rolemenuRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}