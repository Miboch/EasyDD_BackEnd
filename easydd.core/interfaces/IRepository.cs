using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using easydd.core.model;

namespace easydd.core.interfaces
{
    public interface IRepository<TModelType> where TModelType : Entity, new()
    {
        public Task<IQueryable<TModelType>> Collection(Expression<TModelType> exp);
        public Task<IQueryable<TModelType>> Collection();
        public Task<IQueryable<TModelType>> Single(int id);
        public Task<IQueryable<bool>> Delete(int id);
        public Task<IQueryable<TModelType>> Update(int id);
        public Task<IQueryable<TModelType>> Create(int id);
    }
}
