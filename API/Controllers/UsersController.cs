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

        // GET
        [HttpGet]  // api/users
        public ActionResult<IEnumerable<UserReadModel>> GetUsers()
        {
            var users = _repository.ReadUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadModel>>(users));
        }

        // GET
        [HttpGet("{id}", Name="GetUserById")]  // api/users/{id}
        public ActionResult<UserReadModel> GetUserById(int id)
        {
            var user = _repository.ReadUserById(id);
            if(user != null)
            {
                return Ok(_mapper.Map<UserReadModel>(user));
            }

            return NotFound();
        }

        // POST
        [HttpPost]  // api/users/{UserReadModel}
        public ActionResult<UserReadModel> CreateUser(UserCreateModel userCreateModel)
        {
            var userModel = _mapper.Map<User>(userCreateModel);
            _repository.CreateUser(userModel);

            var userReadModel = _mapper.Map<UserReadModel>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadModel.Id }, userReadModel);
        }






        // PUT
        [HttpPut("{id}")]  // api/users/{id}
        public ActionResult UpdateUser(int id, UserUpdateModel userUpdateModel)
        {
            var userModelFromRepo = _repository.ReadUserById(id);
            if(userModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(userUpdateModel, userModelFromRepo);

            _repository.UpdateUser(id);

            return NoContent();

            //var userModel = _mapper.Map<User>(userUpdateModel);
            //_repository.UpdateUser(userModel);

            //var userReadModel = _mapper.Map<UserReadModel>(userModel);
            //return CreatedAtRoute(nameof(GetUserById), new { Id = userReadModel.Id }, userReadModel);
        }









        // DELETE
        [HttpDelete("{id}")]  // api/users/{id}
        public ActionResult<User> DeleteUser(int id)
        {
            var userToDelete = _repository.DeleteUserById(id);
            return Ok(userToDelete);
        }
    }
}
