﻿namespace PillReminder.Comunication.users.Responses
{
    public class DetailedUserJsonResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
    }
}
