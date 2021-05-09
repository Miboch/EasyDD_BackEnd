using System.Threading.Tasks;
using easydd.core.dto;
using easydd.core.interfaces;
using easydd.core.interfaces.service;
using easydd.core.model;
using Microsoft.AspNetCore.Mvc;

namespace easydd.web.Controllers
{
    public class LootController : BaseController<Loot>
    {
        private ILootService _service;

        public LootController(ILootService service) : base(service)
        {
            _service = service;
        }

    }
}
