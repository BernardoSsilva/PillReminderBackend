namespace PillReminder.Communication.images.requests
{
    public class NewImageRequestJson
    {
        public required string ImageName { get; set; }

        public required float ImageSize { get; set; }

        public required string RemedyId { get; set; } 
        public required string ImageBase64Url { get; set; } 
    }
}
