using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SeminarskiRad.Models.IdentityModels;

namespace SeminarskiRad.Services
{
    public class SeminarEmployeeManager:UserManager<SeminarEmployee, int>
    {
        public SeminarEmployeeManager(IUserStore<SeminarEmployee, int> store):base(store)
        {

        }

        public static SeminarEmployeeManager Create(IdentityFactoryOptions<SeminarEmployeeManager> options, IOwinContext context)
        {
            SeminarEmployeeManager manager = new SeminarEmployeeManager(new UserStore<SeminarEmployee, SeminarRole, int, SeminarLogin, SeminarEmployeeRole, SeminarClaim>(context.Get<SeminarskiRad.Models.Context.IdentityDbContext>()));

            manager.UserValidator = new UserValidator<SeminarEmployee, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<SeminarEmployee, int>(dataProtectionProvider.Create("SeminarskiRad"));
            }

            return manager;
        }
    }
}