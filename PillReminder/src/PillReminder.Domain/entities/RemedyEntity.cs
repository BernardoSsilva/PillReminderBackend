namespace PillReminder.Domain.entities
{
    public class RemedyEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RemedyName { get; set; } = string.Empty;
        public string RemedyDosage { get; set; } = string.Empty;
        public List<string> ScheduledHours { get; set; } = [];

        public string UsagePeriod { get; set; } = string.Empty;

        public required string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime? UpdatedAt { get; set; } = null;



    }
}