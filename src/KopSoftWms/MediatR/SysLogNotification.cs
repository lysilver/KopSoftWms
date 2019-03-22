using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YL.Core.Entity;
using YL.Utils.Env;
using IServices;
using YL.NetCore.DI;
using Microsoft.Extensions.DependencyInjection;
using YL.Utils.Log;

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