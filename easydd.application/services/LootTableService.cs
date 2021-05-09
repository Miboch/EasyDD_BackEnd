using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easydd.core.dto;
using easydd.core.interfaces;
using easydd.core.interfaces.repository;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.application.services
{
    public class LootTableService : BaseService<LootTable>, ILootTableService
    {
        private ILootTableRepository _repository;

        public LootTableService(ILootTableRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LootQuantity>> GetLoot(int tableId, int value)
        {
            var loot = (await _repository.Single(tableId))
                .LootChances
                .OrderBy(y => y.WeightedOccurrence)
                .ToList();
            var lootOutcome = new List<LootQuantity>();
            var cumulative = 0;
            var lootedValue = 0;
            foreach (var lootChance in loot)
            {
                cumulative += lootChance.WeightedOccurrence;
                lootChance.WeightedOccurrence = cumulative;
                if (lootChance.GuaranteedFind)
                {
                    lootOutcome.Add(new LootQuantity()
                    {
                        Name = lootChance.Loot.Name,
                        Quantity = 1
                    });
                    lootedValue += lootChance.Loot.Value;
                }
            }

            Random r = new Random();
            while (lootedValue < value)
            {
                var chance = r.Next(0, cumulative);
                var chosenLoot = loot.First(l => l.WeightedOccurrence >= chance);
                var index = lootOutcome.FindIndex(findLoot => findLoot.Name == chosenLoot.Loot.Name);
                if (index > -1)
                {
                    if (lootOutcome[index].Quantity >= chosenLoot.MaxOccurrence && chosenLoot.MaxOccurrence != 0)
                        continue;
                    lootOutcome[index].Quantity += 1;
                    lootedValue += chosenLoot.Loot.Value;
                }
                else
                {
                    lootOutcome.Add(new LootQuantity() {Name = chosenLoot.Loot.Name, Quantity = 1});
                    lootedValue += chosenLoot.Loot.Value;
                }
            }
            return lootOutcome;
        }
    }
}
