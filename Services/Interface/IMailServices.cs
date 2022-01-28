using System.Threading.Tasks;

namespace PeliculasSeries.Services.Interface
{
    public interface IMailServices
    {
        Task SendEmailAsync(string email, string subject, string HtmlContent);
    }
}
