using easydd.core.interfaces;
using easydd.core.model;

namespace easydd.application.services
{
    public class TagService : BaseService<Tag>, ITagService
    {
        private ITagRepository _repository;

        public TagService(ITagRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
