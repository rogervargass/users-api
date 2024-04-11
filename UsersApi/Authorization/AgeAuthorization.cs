using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsersApi.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (birthDateClaim is null)
            {
                return Task.CompletedTask;
            }

            DateTime birthDate = Convert
                .ToDateTime(birthDateClaim.Value);

            int userAge = DateTime.Today.Year - birthDate.Year;

            DateTime limitDate = DateTime.Today.AddYears(-userAge);
            bool isBirthdayBeforeLimit = birthDate > limitDate;

            if (isBirthdayBeforeLimit)
            {
                userAge--;
            }

            int requiredAge = requirement.Age;
            bool meetsAgeRequirement = userAge >= requiredAge;

            if (meetsAgeRequirement)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}