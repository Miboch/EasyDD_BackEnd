using easydd.core.interfaces;
using easydd.core.interfaces.repository;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.application.services
{
    public class EasyImageService : BaseService<EasyImage>, IEasyImageService
    {
        private IEasyImageRepository _repository;

        public EasyImageService(IEasyImageRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
