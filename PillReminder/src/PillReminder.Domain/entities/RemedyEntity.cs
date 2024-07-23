namespace PillReminder.Domain.entities
{
    public class RemedyEntity
    {
        public string Id { get; set; } = new Guid().ToString();
        public required string RemedyName { get; set; }
        public required string RemedyDosage { get; set; }
        public List<string> ScheduledHours { get; set; } = [];

        public string UsagePeriod { get; set; } = string.Empty;

        public required string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime? UpdatedAt { get; set; } = null;



    }
}