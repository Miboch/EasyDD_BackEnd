using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace easydd.core.model
{
    public class Loot : Entity
    {
        public string Name { get; set; }
        public int Value { get; set; }
        [JsonIgnore] public IEnumerable<LootChance> Chances { get; set; }
    }
}
