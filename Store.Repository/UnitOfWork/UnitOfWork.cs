using Store.Data.Context;
using Store.Data.Entity;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDBContext _context;
        private Hashtable _repositories;
        public UnitOfWork(StoreDBContext context)
        {
            _context = context;
        }

       

        public async Task<int> CompletedAsync()
        => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            if (_repositories is null)
            {
                _repositories = new Hashtable();
            }
            var entityKey = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<,>);
                var RepositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity),typeof(Tkey)),_context);
                _repositories.Add(entityKey, RepositoryInstance);
            }
            return (IGenericRepository<TEntity, Tkey>)_repositories[entityKey];
        }
    }
}
