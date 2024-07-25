namespace PillReminder.JWTAdmin
{
    public class TokenPayload
    {
        public string UserId { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
    }
}
