using CarStorage.DAL.Models;
using CarStorage.DAL.Models.Context;
using CarStorage.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Services
{
    public class CarServises
    {
        CarRepository carRepository = new CarRepository(new CarStorageContext());

        public void NewCar(Car car)
        {
            if (car == null)
               new ArgumentNullException("Поле не может быть пустым",nameof(car));
            var a = carRepository.GetAll();
            foreach (var item in a)
            {
                if (item.CarModel == car.CarModel&& item.Year == car.Year)
                {
                    new ArgumentException("Такая машина уже существует");
                }
            }

            carRepository.Save();
        }


    }
}
