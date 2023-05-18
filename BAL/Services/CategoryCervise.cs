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
using System.Runtime.ConstrainedExecution;

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
                var category = categoryRepository.GetById(categoryId).FirstOrDefault();
                if (category == null)
                    throw new CarException("Category is not found");

                categoryRepository.Delete(category);
                categoryRepository.Save();
                Console.WriteLine("Category has been successfully deleted.");
            }
            catch (CategoryException ex)
            {
                throw new CategoryException("Error when removing a category: " + ex.Message);
            }
        }
        #endregion

        #region UpdateCategory
        public void UpdateCategory(Category category)
        {

            try
            {
                if (category == null)
                    throw new CategoryException("Category is update");
                
                var allCategory = categoryRepository.GetAll();
                foreach (var item in allCategory)
                {
                    if (item.CategoryName == category.CategoryName)
                        throw new CarException("category with those name already exist");
                    
                }
                categoryRepository.Update(category);
                categoryRepository.Save();

            }
            catch (CategoryException ex)
            {
                Console.WriteLine("Error update category: " + ex.Message);
            }
        }
        #endregion

        #region NewCategory
        public void NewCategory(Category category)
        {
            try
            {
                if (category.CategoryName == null)
                    throw new CarException("Missing title of issue");

                var existingCategory = categoryRepository.GetAll().FirstOrDefault(item => item.CategoryName == category.CategoryName);

                if (existingCategory == null)
                {
                    categoryRepository.Create(category);
                    categoryRepository.Save();
                }
                else
                    throw new CategoryException("Such a category already exists");
            }

            catch (Exception ex)
            {
                Console.WriteLine("There was a common mistake: " + ex.Message);
            }

        }
        #endregion

        #region FindCategory
        public Category FindCategory(int categoryId)
        {
            try
            {
                var categoryById = categoryRepository.GetById(categoryId).FirstOrDefault();
                if (categoryById == null)
                    throw new CategoryException("Category not found");

                return categoryById;
            }
            catch (CarException ex)
            {
                throw new CarException("Error occurred while finding the car: ");
                return null;
            }
        }
        #endregion




    }
}
