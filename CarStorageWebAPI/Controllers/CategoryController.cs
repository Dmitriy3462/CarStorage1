using CarStorage.BAL.Interfaces;
using CarStorage.BAL.Services;
using CarStorage.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStorageWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("GetAllCategory")]
        public ActionResult FindCategory(int id)
        {
            var category = _categoryService.FindCategory(id);
            return Ok(category);
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
        [HttpPost]
        [Route("AddCategory")]
        public ActionResult AddCategory(Category category)
        {
            _categoryService.NewCategory(category);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public ActionResult UpdateCar(Category category)
        {
            _categoryService.UpdateCategory(category);
            return Ok();
        }
    }


}

