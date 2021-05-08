using System;
using System.Linq;
using System.Threading.Tasks;
using easydd.core.model;

namespace easydd.core.interfaces
{
    public interface IRepository<TModelType> where TModelType : Entity, new()
    {
        public IQueryable<TModelType> Collection();
        public Task<TModelType> Single(int id);
        public Task<bool> Delete(int id);
        public Task<TModelType> Update(TModelType model);
        public Task<TModelType> Create(TModelType model);
    }
}
