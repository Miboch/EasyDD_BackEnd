using easydd.core.model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace easydd.infrastructure.context
{
    public class EasyContext : IdentityDbContext<EasyUser, EasyRole, int>
    {
        public DbSet<Tag> Tags { get; set; }


        public EasyContext(DbContextOptions<EasyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
