using CarStorage.DAL.Models;
using CarStorage.DAL.Models.Context;
using CarStorage.DAL.Repositories;
using CarStorage.BAL.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Services
{
    public class CarServises
    {
        CarRepository carRepository = new CarRepository(new CarStorageContext());


        #region DeleteCar
        public void DeleteCar(int carId)
        {
            try
            {
                var car = carRepository.GetById(carId).FirstOrDefault();
                if (car == null)
                    throw new CarException("Car is not found");
                 
                carRepository.Delete(car);
                carRepository.Save();
                Console.WriteLine("Car has been successfully deleted.");
            }
            catch (CarException ex)
            {
                throw new CarException("Error when removing a car: " + ex.Message);
            }
        }
        #endregion

        #region UpdateCar
        public void UpdateCar(Car car)
        {
            try
            {
                if (car == null)
                {
                    throw new CarException("Car is update");
                }
                var allCar = carRepository.GetAll();
                foreach (var item in allCar)
                {
                    if (item.CarModel == car.CarModel && item.Year == car.Year)
                    {
                        throw new CarException("car with those name and year already exist");
                    }
                }
                carRepository.Update(car);
                carRepository.Save();

            }
            catch (CarException ex)
            {
                Console.WriteLine("Error update car: " + ex.Message);
            }
        }
        #endregion

        #region NewCar
        public void NewCar(Car car)
        {
            try
            {
                if (car.CarModel == null || car.Year == null)
                   throw new CarException ("Missing title or year of issue");                

                var existingCar = carRepository.GetAll().FirstOrDefault(item => item.CarModel == car.CarModel &&
                item.Year == car.Year);

                if (existingCar == null)
                {
                    carRepository.Create(car);
                    carRepository.Save();
                }
                else
                  throw new CarException("Such a machine already exists");                
            }

            catch (Exception ex)
            {
                Console.WriteLine("There was a common mistake: " + ex.Message);
            }

        }
        #endregion

        #region FindCar
        public Car FindCar(int carId)
        {
            try
            {
                var byId = carRepository.GetById(carId).FirstOrDefault();
                if (byId == null)
                    throw new CarException("Car not found");
                
                return byId;
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

