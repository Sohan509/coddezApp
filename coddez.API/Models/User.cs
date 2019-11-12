using System;

namespace coddez.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Location { get; set; }
    }
}