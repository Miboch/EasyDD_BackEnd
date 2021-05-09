using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace easydd.core.model
{
    public class Coin : Entity
    {
        public string Denomination { get; set; }
        public int BaseValue { get; set; }
        public double Probability { get; set; }
        [ForeignKey("CoinLoot")] public int CoinLootId { get; set; }
        public CoinLoot CoinLoot { get; set; }
    }
}
