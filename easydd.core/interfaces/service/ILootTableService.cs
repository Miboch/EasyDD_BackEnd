using System.Collections.Generic;
using System.Threading.Tasks;
using easydd.core.dto;
using easydd.core.model;

namespace easydd.core.interfaces.service
{
    public interface ILootTableService : IService<LootTable>
    {
        Task<IEnumerable<LootQuantity>> GetLoot(int tableId, int value);
    }
}
