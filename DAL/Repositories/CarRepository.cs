using CarStorage.DAL.Interfaces;
using CarStorage.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Repositories
{
    public class CarRepository: Repository<Car>,ICarRepository
    {
        public CarRepository(DbContext context) : base(context)
        {

        }
    }
}
