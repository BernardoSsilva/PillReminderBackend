namespace PillReminder.Communication.images.responses
{
    public class DetailedImageResponseJson
    {

        public string Id { get; set; } = string.Empty;

        public string ImageName { get; set; } = string.Empty;

        public float? ImageSize { get; set; } = null;
        public string RemedyId { get; set; } = string.Empty;
        public string ImageBase64Url { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } 
    }
}
