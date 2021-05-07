using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using easydd.core.interfaces;
using easydd.core.model;

namespace easydd.infrastructure.repository
{
    public class BaseRepository<TModelType> : IRepository<TModelType> where TModelType : Entity, new()
    {
        public Task<IQueryable<TModelType>> Collection(Expression<TModelType> exp)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<TModelType>> Collection()
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<TModelType>> Single(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<TModelType>> Update(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<TModelType>> Create(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
