using CarStorage.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CarStorage.DAL.Repositories
{
    public  class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;
        public Repository(DbContext context)
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

        public TEntity GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
