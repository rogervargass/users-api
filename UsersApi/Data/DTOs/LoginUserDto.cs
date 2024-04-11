using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.DTOs
{
    public class LoginUserDto
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}