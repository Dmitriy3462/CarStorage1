using CarStorage.BAL.Interfaces;
using CarStorage.BAL.Services;
using CarStorage.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStorageWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class CarController : ControllerBase
    {
        private readonly ICarService _carServises;

        public CarController(ICarService carService)
        {
            _carServises = carService;
        }

        [HttpGet]
        [Route("GetAllCars")]
        public ActionResult GetCars()
        {
            var AllCars = _carServises.GetAllCars();
            return Ok(AllCars);
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public ActionResult DeleteCar(int id)
        {
            _carServises.DeleteCar(id);
            return Ok();
        }
        [HttpPost]
        [Route("AddCar")]
        public ActionResult AddCar(Car car)
        {
            _carServises.NewCar(car);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCar")]
        public ActionResult UpdateCar(Car car)
        {
            _carServises.UpdateCar(car);
            return Ok();
        }
    }
}
