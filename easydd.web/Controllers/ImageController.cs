using easydd.core.interfaces;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.web.Controllers
{
    public class ImageController : BaseController<EasyImage>
    {
        private IEasyImageService _service;

        public ImageController(IEasyImageService service) : base(service)
        {
            _service = service;
        }
    }
}
