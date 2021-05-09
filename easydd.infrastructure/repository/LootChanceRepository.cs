using easydd.core.interfaces.repository;
using easydd.core.model;
using easydd.infrastructure.context;

namespace easydd.infrastructure.repository
{
    public class LootChanceRepository : BaseRepository<LootChance>, ILootChanceRepository
    {
        public LootChanceRepository(EasyContext context) : base(context)
        {
        }
    }
}
