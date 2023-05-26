using CarStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Interfaces
{
    public interface ICategoryService
    {
        public void DeleteCategory(int categoryId);
        public void NewCategory(Category category);
        public void UpdateCategory(Category category);
        public Category FindCategory(int categoryId);


    }
}
