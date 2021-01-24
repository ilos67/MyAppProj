using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class IdentityDataContext : DbContext
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}