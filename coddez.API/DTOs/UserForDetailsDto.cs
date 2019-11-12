using System;

namespace coddez.API.DTOs
{
    public class UserForDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Introduction { get; set; }
        public string  LookingFor { get; set; }
        public string Location { get; set; }
    }
}