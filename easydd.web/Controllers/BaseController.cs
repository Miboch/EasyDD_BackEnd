using System;
using System.Threading.Tasks;
using easydd.core.interfaces;
using easydd.core.model;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Single(int id)
        {
            var model = await _service.Single(id);
            if (null == model)
                return StatusCode(StatusCodes.Status400BadRequest, "Could not find entity with given Id");
            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted)
                return StatusCode(StatusCodes.Status400BadRequest, "Cannot delete any such element with id " + id);
            return StatusCode(StatusCodes.Status200OK, "deleted element: " + id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TModelType model)
        {
            var done = await _service.Update(model);
            return Ok(done);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TModelType model)
        {
            var done = await _service.Create(model);
            return Ok(done);
        }
    }
}
