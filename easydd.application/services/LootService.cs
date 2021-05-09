using easydd.core.interfaces;
using easydd.core.interfaces.repository;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.application.services
{
    public class LootService : BaseService<Loot>, ILootService
    {
        private ILootRepository _repository;
        public LootService(ILootRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
