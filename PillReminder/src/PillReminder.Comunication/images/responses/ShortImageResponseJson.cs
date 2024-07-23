namespace PillReminder.Communication.images.responses
{
    public class ImageShortResponseJson
    {

        public string ImageName { get; set; } = string.Empty;

        public float? ImageSize { get; set; } = null;
        public string ImageBase64Url { get; set; } = string.Empty;

    }
}
