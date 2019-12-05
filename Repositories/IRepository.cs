using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3GraphQL.Repositories
{
    public interface IRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> All();
        TEntity Read(int id);
        void Update(TEntity model);
        void Create(TEntity model);
        void Delete(int id);
        void Save();
    }
}