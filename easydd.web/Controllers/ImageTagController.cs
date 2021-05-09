using easydd.core.interfaces;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.web.Controllers
{
    public class ImageTagController : BaseController<EasyImageTag>
    {
        private IEasyImageTagService _service;

        public ImageTagController(IEasyImageTagService service) : base(service)
        {
            _service = service;
        }
    }
}
