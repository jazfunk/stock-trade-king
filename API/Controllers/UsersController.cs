using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _repository;

        public UsersController(IUsersRepo repository)
        {
            _repository = repository;
        }

        // api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _repository.ReadUsers();
            return Ok(users);
        }

        // api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _repository.ReadUserById(id);
            if(user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        // api/users/{User}
        [HttpPost("{user}")]
        public ActionResult<User> CreateUser(User user)
        {
            var userToCreate = _repository.CreateUser(user);
            return Ok(userToCreate);
        }

        // api/users/{User}
        [HttpPut("{user}")]
        public ActionResult<User> UpdateUser(User user)
        {
            var userToUpdate = _repository.UpdateUser(user);
            return Ok(userToUpdate);
        }

        // api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var userToDelete = _repository.DeleteUserById(id);
            return Ok(userToDelete);
        }
    }
}
