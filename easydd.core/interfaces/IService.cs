using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using easydd.core.model;

namespace easydd.core.interfaces
{
    public interface IService<TModelType> where TModelType : Entity, new()
    {
        public Task<IEnumerable<TModelType>> Collection();
        public Task<TModelType> Single(int id);
        public Task<bool> Delete(int id);
        public Task<TModelType> Update(TModelType model);
        public Task<TModelType> Create(TModelType model);


    }
}
