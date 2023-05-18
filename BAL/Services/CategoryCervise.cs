using CarStorage.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStorage.DAL.Models.Context;
using CarStorage.BAL.Helpers;
using CarStorage.DAL.Interfaces;
using CarStorage.DAL.Models;

namespace CarStorage.BAL.Services
{
    public class CategoryCervise
    {
        CategoryRepository categoryRepository = new CategoryRepository(new CarStorageContext());

        #region DeleteCategory
        public void DeleteCategory(int categoryId)
        {
            try
            {
                var category = carRepository.GetById(carId).FirstOrDefault();
                if (category == null)
                    throw new CarException("Car is not found");

                carRepository.Delete(category);
                carRepository.Save();
                Console.WriteLine("Car has been successfully deleted.");
            }
            catch (CarException ex)
            {
                throw new CarException("Error when removing a category: " + ex.Message);
            }
        }
        #endregion

        #region UpdateCategory
        public void UpdateCategory(Category category)
        {
            try
            {
                if (true)
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
