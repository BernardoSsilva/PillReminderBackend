namespace PillReminder.Domain.entities
{
    public class ImageEntity
    {
        public string Id { get; set; } = new Guid().ToString();

        public string ImageName { get; set; } = string.Empty;

        public float ImageSize { get; set; } = 0;

        public string RemedyId { get; set; } = string.Empty;
        public string ImageBase64Url { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = new DateTime();
    }
}
