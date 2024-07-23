using Client.EmailClient.Configuration;
using Client.EmailClient.Interfaces;
using Client.EmailClient.VewModels;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;


namespace Client.EmailClient.MailKit
{
    public class MailKitEmailClient : IMailKitEmailClient
    {
        private readonly EmailConfiguration _emailConfiguration;
        private readonly IViewRender _viewRender;

        public MailKitEmailClient(IViewRender viewRender, IOptionsMonitor<EmailConfiguration> emailConfig)
        {
            _emailConfiguration = emailConfig.CurrentValue ?? throw new ArgumentNullException(nameof(EmailConfiguration));
            _viewRender = viewRender ?? throw new ArgumentNullException(nameof(viewRender));
        }

        public string CreateEmailBody(EmailViewModel emailModel)
        {
            var emailBody = emailModel.Data == null ? File.ReadAllText("./Views/Emails/EmailTemplate.html") : File.ReadAllText("./Views/Emails/DataEmailTemplate.html");
            var body = _viewRender.Render(emailBody, emailModel);
            return body;
        }

        public async Task SendEmailAsync(string mailTo, string subject, string htmlBody)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailConfiguration.appName, _emailConfiguration.smtpUsername));
            mimeMessage.To.Add(new MailboxAddress(mailTo, mailTo));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new Multipart("mixed") { new TextPart(TextFormat.Html) { Text = htmlBody } };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfiguration.smtpServer, _emailConfiguration.smtpPort, false);
                    await client.AuthenticateAsync(_emailConfiguration.smtpUsername, _emailConfiguration.appPassword);
                    await client.SendAsync(mimeMessage);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
