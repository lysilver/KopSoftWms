using IServices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using YL.Core.Entity;
using YL.Utils.Env;

namespace KopSoftWms
{
    public class SysLogNotification : INotificationHandler<Sys_log>
    {
        public Task Handle(Sys_log notification, CancellationToken cancellationToken)
        {
            var _log = GlobalCore.GetRequiredService<ISys_logServices>();
            //var _log = ServiceResolve.Resolve<ISys_logServices>();
            _log.Insert(notification);
            return Task.CompletedTask;
        }
    }
}