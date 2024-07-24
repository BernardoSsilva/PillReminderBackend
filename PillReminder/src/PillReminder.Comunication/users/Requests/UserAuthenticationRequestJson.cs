namespace PillReminder.Communication.users.Requests
{
    public class UserAuthenticationRequestJson
    {
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
    }
}
