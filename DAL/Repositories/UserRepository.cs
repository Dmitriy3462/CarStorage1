using CarStorage.DAL.Interfaces;
using CarStorage.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
