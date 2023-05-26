using CarStorage.BAL.Helpers;
using CarStorage.BAL.Interfaces;
using CarStorage.DAL.Models.Context;
using CarStorage.DAL.Models;
using CarStorage.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Services
{
    public class UserService :IUserService
    {
        UserRepository userRepository = new UserRepository(new CarStorageContext());   

        #region DeleteUser
        public void DeleteUser(int userId)
        {
            try
            {
                var user = repository.GetById(userId).FirstOrDefault();  
                if (user == null)
                    throw new UserException("User is not found");

                repository.Delete(user);
                repository.Save();
                Console.WriteLine("User has been successfully deleted.");
            }
            catch (UserException ex)
            {
                throw new UserException("Error when removing a user: " + ex.Message);
            }
        }
        #endregion

        #region UpdateUser
        public void UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new UserException("User is not update");
                }
                var allUser = userRepository.GetAll();
                foreach (var item in allUser)
                {
                    if (item.FullName == user.FullName && item.PhoneNumber == user.PhoneNumber)
                    {
                        throw new CarExceptoin("user with those name and phone number already exist");
                    }
                }
                userRepository.Update(user);
                userRepository.Save();

            }
            catch (UserException ex)
            {
                Console.WriteLine("Error update user: " + ex.Message);
            }
        }
        #endregion

        #region NewUser
        public void NewUser(User user)
        {
            try
            {
                if (user.FullName == null || user.PhoneNumber == null)
                    throw new CarExceptoin("Missing title or user of issue");

                var existingUser = userRepository.GetAll().FirstOrDefault(item => item.FullName == user.FullName &&
                item.PhoneNumber == user.PhoneNumber);

                if (existingUser == null)
                {
                    userRepository.Create(user);
                    userRepository.Save();
                }
                else
                    throw new UserException("Such a user already exists");
            }

            catch (Exception ex)
            {
                Console.WriteLine("There was a common mistake: " + ex.Message);
            }

        }
        #endregion

        #region FindUser
        public User FindUser(int userId)
        {
            try
            {
                var byId = userRepository.GetById(userId).FirstOrDefault();
                if (byId == null)
                    throw new UserException("User not found");

                return byId;
            }
            catch (UserException ex)
            {
                throw new UserException("Error occurred while finding the car: ");               
            }
           
        }
        #endregion
        public IEnumerable<User> GetAllCars()
        {
            var response = userRepository.GetAll(); 
            return response;
        }
    }
}
