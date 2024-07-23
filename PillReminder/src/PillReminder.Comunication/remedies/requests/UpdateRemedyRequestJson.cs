namespace PillReminder.Communication.remedies.requests
{
    public class UpdateRemedyJsonRequest
    {
        public  string? RemedyName { get; set; }
        public  string? RemedyDosage { get; set; }
        public List<string>? ScheduledHours { get; set; } 

        public string? UsagePeriod { get; set; } = string.Empty;

    }
}
