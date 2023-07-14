using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using FluentEmail.Core;
using FluentEmail.Smtp;
using FluentEmail.Core.Models;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        
        public static async Task SendEmail(string to, string subject, string body)
        {
            await SendEmail(new List<string> { to }, new List<string>(), subject, body);
        }

        public static async Task SendEmail(List<string> to, List<string> bcc, string subject, string body)
        {
            string fromEmail = GlobalConfig.AppKeyLookup("senderEmail");
            string fromDisplayName = GlobalConfig.AppKeyLookup("senderDisplayName");

            List<Address> toAddresses = new List<Address>();
            toAddresses = to.Select(ea => new Address { EmailAddress = ea }).ToList();

            List<Address> bccAddresses = new List<Address>();
            bccAddresses = bcc.Select(ea => new Address { EmailAddress = ea }).ToList();

            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From(fromEmail,fromDisplayName)
                .To(toAddresses)
                .BCC(bccAddresses)
                .Subject(subject)
                .Body(body,isHtml: true)
                .SendAsync();
        }
    }
}
