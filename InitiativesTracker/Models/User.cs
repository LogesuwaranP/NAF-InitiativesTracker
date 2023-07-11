﻿namespace InitiativesTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? DataOfBirth { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; } = "User";

    }
}