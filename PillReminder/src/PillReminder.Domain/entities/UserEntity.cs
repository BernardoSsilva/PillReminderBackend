namespace PillReminder.Domain.entities
{
    public class UserEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;

        public  string Email { get; set; } = string.Empty;

        public  string Password { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime? UpdatedAt { get; set; } = null;

    }
}
