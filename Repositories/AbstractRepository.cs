using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppContext = WebApplication3GraphQL.Contexts.AppContext;

namespace WebApplication3GraphQL.Repositories
{
    public class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public AbstractRepository(AppContext dbContext)
        {
            _context = dbContext;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<TEntity> All()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity Read(int id)
        {
            return _context.Find<TEntity>(id);
        }

        public void Update(TEntity model)
        {
            _context.Update(model);
            this.Save();
        }

        public void Create(TEntity model)
        {
            _context.Add(model);
            this.Save();
        }

        public void Delete(int id)
        {
            TEntity entity = _context.Find<TEntity>(id);
            if (entity != null)
            {
                _context.Remove(entity);
            }
            else
            {
                throw  new NullReferenceException();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}