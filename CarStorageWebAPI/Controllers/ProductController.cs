using CarStorage.BAL.Interfaces;
using CarStorage.BAL.Services;
using CarStorage.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStorageWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public ActionResult GetProducts()
        {
            var AllProduct = _productService.GetAllProduct();
            return Ok(AllProduct);
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult AddProduct(Product product)
        {
            _productService.NewProduct(product);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product); 
            return Ok();
        }
    }
}
