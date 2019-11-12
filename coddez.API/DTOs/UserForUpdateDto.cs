using System;

namespace coddez.API.DTOs
{
    public class UserForUpdateDto
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Introduction { get; set; }
        public string  LookingFor { get; set; }
        public string Location { get; set; }
    }
}