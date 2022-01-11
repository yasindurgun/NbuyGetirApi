using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public class EmailAttachment
    {
        public string Base64 { get; set; }
        public byte[] File { get; set; }
    }
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string message, string cc, List<EmailAttachment
            > emailAttachments = null);
    }
}
