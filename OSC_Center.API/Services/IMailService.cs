using Library.DataModel.DTO;
using System.Threading.Tasks;
namespace Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}