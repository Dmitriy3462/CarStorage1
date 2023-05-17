using CarStorage.DAL.Interfaces;
using CarStorage.DAL.Models;
using CarStorage.DAL.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Repositories
{
    public class CarRepository: Repository<Car>,ICarRepository
    {
        public CarRepository(CarStorageContext context) : base(context)
        {

        }
        public IQueryable<Car> GetById(int id)
        {
            return _entities.Where(x=>x.Id==id);
        }
        public IQueryable<Car> GetByNameAndYear(string name,DateTime year)
        {
            return _entities.Where(x => x.CarModel == name && x.Year==year);              
        }
    }
}
