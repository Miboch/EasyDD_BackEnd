using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using easydd.core.interfaces;
using easydd.core.model;

namespace easydd.application.services
{
    public class BaseService<TModelType> : IService<TModelType> where TModelType : Entity, new()
    {
        public Task<IEnumerable<TModelType>> Collection(Expression<TModelType> exp)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TModelType>> Collection()
        {
            throw new System.NotImplementedException();
        }

        public Task<TModelType> Single(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TModelType> Update(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TModelType> Create(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
