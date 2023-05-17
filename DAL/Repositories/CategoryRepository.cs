using CarStorage.DAL.Interfaces;
using CarStorage.DAL.Models;
using CarStorage.DAL.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CarStorageContext context) : base(context)
        {

        }
        public IQueryable<Category> GetById(int id)
        {
            return _entities.Where(x => x.Id == id);
        }

        public IQueryable<Category> GetByName(string name)
        {
            return _entities.Where(x => x.CategoryName == name);
        }
    }
}
