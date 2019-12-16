using System.Collections.Generic;
using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Repositories;

namespace WebApplication3GraphQL.Services
{
    public class SensorGroupsService : ISensorGroupsService
    {
        private readonly ISensorsGroupsRepository _repository;

        public SensorGroupsService(ISensorsGroupsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SensorsGroups> All()
        {
            return _repository.All();
        }

        public SensorsGroups Read(int id)
        {
            return _repository.Read(id);
        }

        public void Update(int id, SensorsGroups model)
        {
            if (model.Id == null)
            {
                model.Id = id;
            }
            _repository.Update(model);
        }

        public void Create(SensorsGroups model)
        {
            _repository.Create(model);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}