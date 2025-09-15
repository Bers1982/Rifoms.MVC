//using MailKit.Net.Smtp;
//using MailKit.Security;

using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using Rifoms.Domain.Infrastructure.Interfaces;
using Rifoms.Domain.Infrastructure.Settings;
using Rifoms.Domain.Infrastructure.Helper;

namespace Rifoms.Domain.Infrastructure.Services
{
    /// <summary>
    /// Образец кода взял с https://codewithmukesh.com/blog/send-emails-with-aspnet-core/ 
    /// </summary>
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;
        public MailService(IOptions<MailSettings> _mailSettings)
        {
            mailSettings = _mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            #region NEW_CODE
            //Образец кода взял с https://codewithmukesh.com/blog/send-emails-with-aspnet-core/

            //var email = new MimeMessage();
            //email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.From);
            //email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            //email.Subject = mailRequest.Subject;
            //var builder = new BodyBuilder();

            //if (mailRequest.Attachments?.Count > 0)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, MimeKit.ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}

            //builder.HtmlBody = mailRequest.Body;
            //email.Body = builder.ToMessageBody();
            //try
            //{
            //    using var smtp = new MailKit.Net.Smtp.SmtpClient();

            //    smtp.Connect(mailSettings.Host, mailSettings.Port);
            //    await smtp.SendAsync(email);
            //    smtp.Disconnect(true);
            //}
            //catch (System.Exception ex)
            //{
            //    throw new System.Exception(ex.Message);
            //}            
            #endregion

            #region OLD_CODE
            MailMessage mailObj = new MailMessage(new MailAddress(mailSettings.From, mailSettings.DisplayName, Encoding.UTF8),
                new MailAddress(mailRequest.ToEmail))
            {
                Subject = mailRequest.Subject,
                Body = mailRequest.Body,
                IsBodyHtml = true
            };
            SmtpClient SMTPServer = new SmtpClient(mailSettings.Host, mailSettings.Port);

            //Отправка писем с вложениями не работает, надо разобраться почему :((
            if (mailRequest.Attachments?.Count > 0)
            {
                //byte[] fileBytes;
                foreach (var formFile in mailRequest.Attachments)
                {
                    if (formFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            formFile.CopyTo(ms);
                            //fileBytes = ms.ToArray();

                            mailObj.Attachments.Add(new Attachment(ms, new System.Net.Mime.ContentType(formFile.ContentType)));
                            //formFile.FileName, fileBytes, new System.Net.Mime.ContentType(formFile.ContentType));
                        }

                    }
                }
            }
            try
            {
                await SMTPServer.SendMailAsync(mailObj);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            #endregion
        }
    }
}
