using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersApi.Models;

namespace UsersApi.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> opts) : IdentityDbContext<User>(opts)
    {
    }
}
