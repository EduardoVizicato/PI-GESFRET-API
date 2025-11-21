using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TMS.Application.Models;
using TMS.Application.Services.Interfaces;

namespace TMS.Application.Services.Implementation
{
    public class GmailService : IMailService
    {
        private readonly GmailOptions _options;

        public GmailService(IOptions<GmailOptions> options)
        {
            _options = options.Value;
        }

        public async Task SendEmailAsync(SendEmailRequest request)
        {
            MailMessage message = new MailMessage 
            {
                From = new MailAddress(_options.Email),
                Subject = request.Subject,
                Body = request.Body,
            };
            message.To.Add(request.Recipient);

            var smtpClient = new SmtpClient();
            smtpClient.Host = _options.Host;
            smtpClient.Port = _options.Port;
            smtpClient.Credentials = new NetworkCredential(
                _options.Email, _options.Password);
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(message);
        }
    }
}
