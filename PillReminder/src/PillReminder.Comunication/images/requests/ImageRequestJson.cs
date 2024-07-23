namespace PillReminder.Communication.images.requests
{
    public class NewImageRequestJson
    {
        public  string ImageName { get; set; } = string.Empty;

        public float ImageSize { get; set; } = 0;

        public  string RemedyId { get; set; } = string.Empty;
        public  string ImageBase64Url { get; set; } = string.Empty;
    }
}
