using System.Collections.Generic;

namespace WebApplication3GraphQL.Services
{
    public interface IService<TEntity>
    {
        IEnumerable<TEntity> All();
        TEntity Read(int id);
        void Update(int id, TEntity model);
        void Create(TEntity model);
        void Delete(int id);
    }
}