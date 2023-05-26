using CarStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Interfaces
{
    public interface IProductService
    {
        public void DeleteProduct(int productId);
        public void UpdateProduct(Product product);
        public void NewProduct(Product product);
        public Product FindProduct(int productId);
        public IEnumerable<Product> GetAllProduct();
    }
}
