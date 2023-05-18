using CarStorage.DAL.Models;
using CarStorage.DAL.Models.Context;
using CarStorage.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Services
{
    public class CarServises
    {
        CarRepository carRepository = new CarRepository(new CarStorageContext());

        public void NewCar(Car car)
        {
            
            if (car.CarModel == null || car.Year == null)
                new ArgumentException("Отсутсвует название или год выпуска");
            if (car.Year.Year < 1900 || car.Year.Year > DateTime.Now.Year)
                new ArgumentException("Год выпуска введен неверно");                   
            var a = carRepository.GetAll();
            foreach (var item in a)
            {
                if (item.CarModel == car.CarModel&& item.Year == car.Year)
                {
                    new ArgumentException("Такая машина уже существует");
                }
            }
            carRepository.Create(car);

            carRepository.Save();
        }
        public Car FindCar (int carId)
        {
            var b = carRepository.GetAll();
            foreach (var item in b)
            {
                if (item.Id == carId)
                {
                    return item;
                }
            }
            Console.WriteLine("Машина не найдена");
            return null;
        }

        
    }
}
