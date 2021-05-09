using System.Threading.Tasks;
using easydd.core.interfaces;
using easydd.core.interfaces.service;
using easydd.core.model;
using Microsoft.AspNetCore.Mvc;

namespace easydd.web.Controllers
{
    public class LootTableController : BaseController<LootTable>
    {
        private ILootTableService _service;

        public LootTableController(ILootTableService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("loot")]
        public async Task<IActionResult> GetLoot(int tableId, int value)
        {
            return Ok(await _service.GetLoot(tableId, value));
        }
    }
}
