using System.Collections.Generic;
using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Repositories;

namespace WebApplication3GraphQL.Services
{
    public class SensorDatasService : ISensorDatasService
    {
        private readonly ISensorDatasRepository _repository;

        public SensorDatasService(ISensorDatasRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SensorDatas> All()
        {
            return _repository.All();
        }

        public SensorDatas Read(int id)
        {
            return _repository.Read(id);
        }

        public void Update(int id, SensorDatas model)
        {
            if (model.Id == null)
            {
                model.Id = id;
            }
            _repository.Update(model);
        }

        public void Create(SensorDatas model)
        {
            _repository.Create(model);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}