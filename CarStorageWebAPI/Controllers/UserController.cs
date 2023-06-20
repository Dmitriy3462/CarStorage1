using CarStorage.BAL.Interfaces;
using CarStorage.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStorageWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService; 

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetUsers()
        {
            var AllUsers = _userService.GetAllUsers();
            return Ok(AllUsers);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
        [HttpPost]
        [Route("AddUser")]
        public ActionResult AddUser(User user)
        {
            _userService.NewUser(user);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult UpdateUser(User user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }
    }
}
