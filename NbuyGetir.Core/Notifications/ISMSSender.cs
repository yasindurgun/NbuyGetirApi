using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public interface ISMSSender
    {
        Task SendSmsAsync(string PhoneNumber, string message);
    }
}
