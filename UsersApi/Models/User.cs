using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsersApi.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
    }
}