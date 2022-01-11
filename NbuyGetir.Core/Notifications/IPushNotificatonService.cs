using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public interface IPushNotificatonService
    {
        Task SendPushNotificationAsync(string appId, string message);
    }
}
