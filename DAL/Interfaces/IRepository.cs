using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Interfaces
{
    public interface IRepository<T>
       
    {
        void Create(T entity);
        void Save();
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
       

    }
}
