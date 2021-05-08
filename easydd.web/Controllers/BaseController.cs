using System.Threading.Tasks;
using easydd.core.interfaces;
using easydd.core.model;
using Microsoft.AspNetCore.Mvc;

namespace easydd.web.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<TModelType> : ControllerBase where TModelType : Entity, new()
    {
        private IService<TModelType> _service;

        public BaseController(IService<TModelType> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Collection()
        {
            return Ok(await _service.Collection());
        }
    }
}
