using CarStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
        IQueryable<Product> GetByNameCategoryIdNameProduct(int carId, int categoryId, string nameProd);

    }
}
