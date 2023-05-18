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
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(CarStorageContext context) : base(context)
        {

        }

        public IQueryable<Product> GetByNameCategoryIdNameProduct(int carId, int categoryId, string nameProd)
        {
            return _entities.Where(x => x.CarId == carId
            && x.CategoryId == categoryId && x.Name == nameProd);
        }
        public IQueryable<Product> GetById(int id)
        {
            return _entities.Where(x => x.Id == id);
        }
    }
}
