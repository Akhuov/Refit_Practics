using Microsoft.EntityFrameworkCore;
using Wep_1.Application.Absreactions;
using Wep_1.Domain;

namespace Wep_1.Infrastructure.Persistance
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
