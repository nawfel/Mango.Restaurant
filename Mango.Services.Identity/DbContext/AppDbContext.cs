using Mango.Services.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Identity.DbContext
{
    public class AppLocalContext : IdentityDbContext<ApplicationUser>
    {
       
        public AppLocalContext(DbContextOptions<AppLocalContext> options):base(options)
        {
            
        }

    }
}
