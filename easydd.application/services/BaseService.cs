using System.Collections.Generic;
using System.Threading.Tasks;
using easydd.core.interfaces;
using easydd.core.model;
using Microsoft.EntityFrameworkCore;

namespace easydd.application.services
{
    public class BaseService<TModelType> : IService<TModelType> where TModelType : Entity, new()
    {
        private IRepository<TModelType> _repository;

        public BaseService(IRepository<TModelType> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<TModelType>> Collection()
        {
            return await _repository.Collection().ToListAsync();
        }

        public virtual async Task<TModelType> Single(int id)
        {
            return await _repository.Single(id);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<TModelType> Update(TModelType model)
        {
            return await _repository.Update(model);
        }

        public virtual async Task<TModelType> Create(TModelType model)
        {
            return await _repository.Create(model);
        }
    }
}
