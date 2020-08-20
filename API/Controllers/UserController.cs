using AutoMapper;
using Core.Entities;
using Infrastructure;
using API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
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
        [HttpGet("{id}", Name = "GetUserById")]  // api/users/{id}
        public ActionResult<UserReadModel> GetUserById(int id)
        {
            var user = _repository.ReadUserById(id);
            if (user != null)
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
            if (userModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(userUpdateModel, userModelFromRepo);

            _repository.UpdateUser(userModelFromRepo);

            return NoContent();
        }

        // PATCH
        [HttpPatch("{id}")] // API/users/{id}
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateModel> patchDoc)
        {
            var userModelFromRepo = _repository.ReadUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }

            var userToPatch = _mapper.Map<UserUpdateModel>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);

            if(!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userModelFromRepo);

            _repository.UpdateUser(userModelFromRepo);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]  // api/users/{id}
        public ActionResult<User> DeleteUser(int id)
        {
            var userModelFromRepo = _repository.ReadUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteUserById(id);

            return NoContent();
        }
    }
}
