using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace easydd.core.model
{
    public class LootTable : Entity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        [JsonIgnore] public IEnumerable<LootChance> LootChances { get; set; }
    }
}
