using Microsoft.EntityFrameworkCore;
using Wep_1.Domain.Entities;

namespace Wep_1.Application.Absreactions
{
    public interface IApplicationContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

            
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
