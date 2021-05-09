using easydd.application.services;
using easydd.core.interfaces;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.web.Controllers
{
    public class TagController : BaseController<Tag>
    {
        private ITagService _service;
        public TagController(ITagService service) : base(service)
        {
            _service = service;
        }
    }
}
