using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace easydd.core.model
{
    public class LootChance : Entity
    {
        public int WeightedOccurrence { get; set; } = 1;
        public bool GuaranteedFind { get; set; } = false;
        public int MaxOccurrence { get; set; } = 0;
        [ForeignKey("Loot")] public int LootId { get; set; }
        [JsonIgnore] public Loot Loot { get; set; }
        [ForeignKey("LootTable")] public int LootTableId { get; set; }
        [JsonIgnore] public LootTable LootTable { get; set; }
    }
}
