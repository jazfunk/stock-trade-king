using AutoMapper;
using Core.Entities;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadModel>> GetUsers()
        {
            var users = _repository.ReadUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadModel>>(users));
        }

        // api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserReadModel> GetUserById(int id)
        {
            var user = _repository.ReadUserById(id);
            if(user != null)
            {
                return Ok(_mapper.Map<UserReadModel>(user));
            }

            return NotFound();
        }





        // Left off video here at creating the user

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
