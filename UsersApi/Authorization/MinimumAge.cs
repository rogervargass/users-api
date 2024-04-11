using Microsoft.AspNetCore.Authorization;

namespace UsersApi.Authorization
{
    public class MinimumAge(int age) : IAuthorizationRequirement
    {
        public int Age { get; set; } = age;
    }
}