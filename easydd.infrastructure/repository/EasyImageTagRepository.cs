using easydd.core.interfaces.repository;
using easydd.core.model;
using easydd.infrastructure.context;

namespace easydd.infrastructure.repository
{
    public class EasyImageTagRepository : BaseRepository<EasyImageTag>, IEasyImageTagRepository
    {
        public EasyImageTagRepository(EasyContext context) : base(context)
        {
        }
    }
}
