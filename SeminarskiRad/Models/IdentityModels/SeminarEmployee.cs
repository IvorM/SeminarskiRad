using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SeminarskiRad.Services;

namespace SeminarskiRad.Models.IdentityModels
{
    public class SeminarEmployee : IdentityUser<int, SeminarLogin, SeminarEmployeeRole, SeminarClaim>
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(SeminarEmployeeManager userManager)
        {
            var userIdentity = await userManager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}