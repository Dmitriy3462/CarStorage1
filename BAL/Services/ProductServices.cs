using CarStorage.BAL.Helpers;
using CarStorage.DAL.Models.Context;
using CarStorage.DAL.Models;
using CarStorage.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStorage.BAL.Interfaces;
using CarStorage.DAL.Interfaces;

namespace CarStorage.BAL.Services
{
    public class ProductServices : IProductService
    {
        ProductRepository productRepository = new ProductRepository(new CarStorageContext());

        #region DeleteProduct
        public void DeleteProduct(int productId)
        {
            try
            {
                var product = productRepository.GetById(productId).FirstOrDefault();
                if (product == null)
                    throw new ProductException("product is not found");

                productRepository.Delete(product);
                productRepository.Save();
                Console.WriteLine("product has been successfully deleted.");
            }
            catch (ProductException ex)
            {
                throw new ProductException("Error when removing a product: " + ex.Message);
            }
        }
        #endregion



        #region UpdateProduct
        public void UpdateProduct(Product product)
        {

            try
            {
                if (product == null)
                    throw new ProductException("product is update");

                var allProduct = productRepository.GetAll();
                foreach (var item in allProduct)
                {
                    if (item.Name == product.Name)
                        throw new ProductException("product with those name already exist");

                }
                productRepository.Update(product);
                productRepository.Save();

            }
            catch (ProductException ex)
            {
                Console.WriteLine("Error update product: " + ex.Message);
            }
        }
        #endregion

        #region NewProduct
        public void NewProduct(Product product)
        {
            try
            {
                if (product.Name == null)
                    throw new ProductException("Missing title of issue");

                var existingCategory = productRepository.GetAll().FirstOrDefault(item => item.Name == product.Name);

                if (existingCategory == null)
                {
                    productRepository.Create(product);
                    productRepository.Save();
                }
                else
                    throw new ProductException("Such a product already exists");
            }

            catch (Exception ex)
            {
                Console.WriteLine("There was a common mistake: " + ex.Message);
            }

        }
        #endregion

        #region FindProduct
        public Product FindProduct(int productId)
        {
            try
            {
                var productById = productRepository.GetById(productId).FirstOrDefault();
                if (productById == null)
                    throw new CategoryException("product not found");

                return productById;
            }
            catch (ProductException ex)
            {
                throw new ProductException("Error occurred while finding the product: ");
                return null; //????????????
            }
        }
        #endregion

        public IEnumerable<Product> GetAllProduct()
        {
            var response = productRepository.GetAll();
            return response;
        }


    }

    //Доделать и проверить соотвествие проверок и анологично сделать для юзера
}
