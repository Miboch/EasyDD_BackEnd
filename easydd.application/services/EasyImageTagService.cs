using easydd.core.interfaces;
using easydd.core.interfaces.repository;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.application.services
{
    public class EasyImageTagService : BaseService<EasyImageTag>, IEasyImageTagService
    {
        private IEasyImageTagRepository _repository;

        public EasyImageTagService(IEasyImageTagRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
