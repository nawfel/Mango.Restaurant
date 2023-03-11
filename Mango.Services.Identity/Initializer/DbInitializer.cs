using IdentityModel;
using Mango.Services.Identity.DbContext;
using Mango.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Services.Identity.Initializer
{
    public class DbInitializer :IDbInitializer
    {
        private readonly AppLocalContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(AppLocalContext context,UserManager<ApplicationUser>  userManager,RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(StaticDetails.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Customer)).GetAwaiter().GetResult();
            }
            else return;
            ApplicationUser adminUser = new ApplicationUser
            {
                UserName = "admin@local.fr",
                Email = "admin@local.fr",
                EmailConfirmed = true,
                PhoneNumber = "0753970599",
                FirstName="Ben",
                LastName="Admin"                
            };
            _userManager.CreateAsync(adminUser,"admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser,StaticDetails.Admin).GetAwaiter().GetResult();

           var admin= _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+" "+adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticDetails.Admin)
            }).Result;

            ApplicationUser custumerUser = new ApplicationUser
            {
                UserName = "customer@local.fr",
                Email = "customer@local.fr",
                EmailConfirmed = true,
                PhoneNumber = "0753970599",
                FirstName = "Ben",
                LastName = "user"
            };
            _userManager.CreateAsync(custumerUser, "admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(custumerUser, StaticDetails.Customer).GetAwaiter().GetResult();

            var user = _userManager.AddClaimsAsync(adminUser, new Claim[]
             {
                new Claim(JwtClaimTypes.Name,custumerUser.FirstName+" "+custumerUser.LastName),
                new Claim(JwtClaimTypes.GivenName,custumerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,custumerUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticDetails.Customer)
             }).Result;
        }
    }
}
