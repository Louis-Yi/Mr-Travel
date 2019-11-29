using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Mr_Travel.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public async Task SendAsync(String toEmail)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var subject = "Confirm";
            var body = "Your reservation is been confirmed";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, "");
            var bytes = File.ReadAllBytes("D:\\file.jpg");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("file.jpg", file);
            var response = await client.SendEmailAsync(msg);
        }
    }
}