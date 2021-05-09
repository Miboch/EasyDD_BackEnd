using System.Threading.Tasks;
using easydd.core.interfaces.repository;
using easydd.core.model;
using easydd.infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace easydd.infrastructure.repository
{
    public class LootTableRepository : BaseRepository<LootTable>, ILootTableRepository
    {
        public LootTableRepository(EasyContext context) : base(context)
        {
        }

        public override async Task<LootTable> Single(int id)
        {
            return await DbSet.Include(x => x.LootChances).ThenInclude(z => z.Loot)
                .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
}
