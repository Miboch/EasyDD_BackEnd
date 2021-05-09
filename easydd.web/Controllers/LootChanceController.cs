using easydd.core.interfaces;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.web.Controllers
{
    public class LootChanceController : BaseController<LootChance>
    {
        private ILootChanceService _service;
        public LootChanceController(ILootChanceService service) : base(service)
        {
            _service = service;
        }
    }
}
