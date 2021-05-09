using easydd.core.model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace easydd.infrastructure.context
{
    public class EasyContext : IdentityDbContext<EasyUser, EasyRole, int>
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Loot> Loot { get; set; }
        public DbSet<LootChance> LootChances { get; set; }
        public DbSet<LootTable> LootTables { get; set; }


        public EasyContext(DbContextOptions<EasyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Tag>().HasData(new[]
            {
                new Tag()
                {
                    Id = 1,
                    Label = "Sticker"
                },
                new Tag()
                {
                    Id = 2,
                    Label = "Background"
                }
            });
            builder.Entity<Loot>().HasData(new[]
            {
                new Loot() {Id = 1, Value = 1, Name = "Copper"},
                new Loot() {Id = 2, Value = 10, Name = "Silver"},
                new Loot() {Id = 3, Value = 50, Name = "Electrum"},
                new Loot() {Id = 4, Value = 100, Name = "Gold"},
                new Loot() {Id = 5, Value = 100, Name = "Platinum"}
            });
            builder.Entity<LootTable>().HasData(new LootTable()
            {
                Id = 1,
                Name = "Simple Coins",
                Note = "A mix of silver and copper with a low chance of golden coins appearing (max 2)"
            });
            builder.Entity<LootChance>().HasData(new[]
            {
                new LootChance() {Id = 1, LootId = 1, WeightedOccurrence = 20, LootTableId = 1},
                new LootChance() {Id = 2, LootId = 2, WeightedOccurrence = 10, LootTableId = 1},
                new LootChance() {Id = 3, LootId = 4, WeightedOccurrence = 1, MaxOccurrence = 2, LootTableId = 1}
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
