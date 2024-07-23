namespace PillReminder.Communication.remedies.requests
{
    public class RemedyJsonRequest
    {
        public  string RemedyName { get; set; } = string.Empty;
        public  string RemedyDosage { get; set; } = string.Empty;
        public List<string> ScheduledHours { get; set; } = [];

        public string UsagePeriod { get; set; } = string.Empty;

        public  string UserId { get; set; } = string.Empty;
    }
}
