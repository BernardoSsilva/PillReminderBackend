namespace PillReminder.Communication.remedies.requests
{
    public class NewRemedyJsonRequest
    {
        public required string RemedyName { get; set; }
        public required string RemedyDosage { get; set; }
        public List<string> ScheduledHours { get; set; } = [];

        public string UsagePeriod { get; set; } = string.Empty;

        public required string UserId { get; set; }
    }
}
