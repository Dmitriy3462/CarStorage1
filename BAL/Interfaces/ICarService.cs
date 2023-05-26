using CarStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Interfaces
{
    public interface ICarService
    {
        public void DeleteCar(int carId);
        public void UpdateCar(Car car);
        public void NewCar(Car car);
        public Car FindCar(int carId);
        public IEnumerable<Car> GetAllCars();
    }
}
