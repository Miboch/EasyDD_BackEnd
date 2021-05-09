using easydd.core.interfaces.repository;
using easydd.core.model;
using easydd.infrastructure.context;

namespace easydd.infrastructure.repository
{
    public class LootRepository : BaseRepository<Loot>, ILootRepository
    {
        public LootRepository(EasyContext context) : base(context)
        {
        }
    }
}
