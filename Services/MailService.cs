using PeliculasSeries.Services.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeliculasSeries.Services
{
    public class MailServices : IMailServices
    {
        public async Task SendEmailAsync(string email, string subject, string HtmlContent)
        {
            var key = "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"; 
            var client = new SendGridClient(key);
            var from = new EmailAddress("arielezequielperez@gmail.com", "Ariel");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(HtmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, HtmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
