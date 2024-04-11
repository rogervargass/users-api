using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required DateTime BirthDate { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required]
        [Compare("Password")]
        public required string PasswordConFirmation { get; set; }
    }
}
