using CarStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Interfaces
{
    public interface ICarRepository:IRepository<Car>
    {
        IQueryable<Car> GetByNameAndYear(string name,DateTime year );      
    }
}
