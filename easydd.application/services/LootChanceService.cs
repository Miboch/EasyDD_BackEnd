using easydd.core.interfaces;
using easydd.core.interfaces.repository;
using easydd.core.interfaces.service;
using easydd.core.model;

namespace easydd.application.services
{
    public class LootChanceService : BaseService<LootChance>, ILootChanceService
    {
        private ILootChanceRepository _repository;
        public LootChanceService(ILootChanceRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
