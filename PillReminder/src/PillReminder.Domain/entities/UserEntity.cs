namespace PillReminder.Domain.entities
{
    public class UserEntity
    {
        public string Id { get; set; } = new Guid().ToString();
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime? UpdatedAt { get; set; } = null;

    }
}
