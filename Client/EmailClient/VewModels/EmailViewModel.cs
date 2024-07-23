namespace Client.EmailClient.VewModels
{
    public class EmailViewModel
    {
        public required string Title { get; set; }
        public required string Header { get; set; }
        public required string Message { get; set; }
        public string? Data { get; set; }
    }
}
