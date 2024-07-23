namespace Client.EmailClient.Configuration
{
    public class EmailConfiguration
    {
        public string smtpServer { get; set; }
        public int smtpPort { get; set; }
        public string smtpUsername { get; set; }
        public string smtpPassword { get; set; }
        public string appName { get; set; }
        public string appPassword { get; set; }
    }
}
