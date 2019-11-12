using System.ComponentModel.DataAnnotations;

namespace coddez.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(10,MinimumLength=6,ErrorMessage="Password should be length 6 to 10")]
        public string Password { get; set; }
    }
}