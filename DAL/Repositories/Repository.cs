using CarStorage.DAL.Interfaces;
using CarStorage.DAL.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CarStorage.DAL.Repositories
{
    public  class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly CarStorageContext _context;
        protected readonly DbSet<TEntity> _entities;
        public Repository(CarStorageContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        

        public void Update(TEntity entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
            //почитать про этот метод 
        }

        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
