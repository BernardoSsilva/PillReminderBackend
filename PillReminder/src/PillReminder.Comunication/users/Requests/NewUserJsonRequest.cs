namespace PillReminder.Comunication.users.Requests
{
    public class NewUserJsonRequest
    {
        public required string Name { get; set; }

        public required string Email { get; set; } 

        public required string Password { get; set; } 
    }
}
