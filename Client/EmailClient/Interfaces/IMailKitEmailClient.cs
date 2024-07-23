using Client.EmailClient.VewModels;

namespace Client.EmailClient.Interfaces
{
    public interface IMailKitEmailClient
    {
        string CreateEmailBody(EmailViewModel emailModel);
        Task SendEmailAsync(string mailTo, string subject, string body);
    }
}