using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace easydd.core.model
{
    public class CoinLoot : Entity
    {
        public string LootName { get; set; }
        public IEnumerable<Coin> Coins { get; set; }

        public CoinLoot()
        {
            Coins = new List<Coin>();
        }
    }
}
