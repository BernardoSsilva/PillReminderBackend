namespace PillReminder.Communication.remedies.responses
{
    public class RemedyDetailedJsonResponse
    {
        public string Id { get; set; } = string.Empty;
        public string RemedyName { get; set; } = string.Empty;
        public string RemedyDosage { get; set; } = string.Empty;
        public List<string> ScheduledHours { get; set; } = [];

        public string UsagePeriod { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; } 
    }
}
