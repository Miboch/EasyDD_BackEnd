using easydd.core.interfaces.repository;
using easydd.core.model;
using easydd.infrastructure.context;

namespace easydd.infrastructure.repository
{
    public class EasyImageRepository : BaseRepository<EasyImage>, IEasyImageRepository
    {
        public EasyImageRepository(EasyContext context) : base(context)
        {
        }
    }
}
