using System.ComponentModel.DataAnnotations;

namespace coddez.API.DTOs
{
    public class UserForLoginDto
    {
        
        [Required]        
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}