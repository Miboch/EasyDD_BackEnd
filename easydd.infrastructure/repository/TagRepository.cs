using easydd.core.interfaces;
using easydd.core.model;
using easydd.infrastructure.context;

namespace easydd.infrastructure.repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(EasyContext context) : base(context)
        {
        }
    }
}
