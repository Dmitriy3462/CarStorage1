using CarStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Interfaces
{
    public interface IUserService
    {
        public void DeleteUser(int userId);
        public void UpdateUser(User user);
        public void NewUser(User user);
        public User FindUser(int userId);
        public IEnumerable<User> GetAllUsers();
    }
}
