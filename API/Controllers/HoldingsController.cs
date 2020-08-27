using AutoMapper;
using Core.Entities;
using Infrastructure;
using API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/holdings")]
    [ApiController]

    public class HoldingsController : ControllerBase
    {
        private readonly IHoldingsRepo _repository;
        private readonly IMapper _mapper;

        public HoldingsController(IHoldingsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET
        [HttpGet] // api/holdings
        public ActionResult<IEnumerable<HoldingsReadModel>> GetAllHoldings()
        {
            var items = _repository.ReadAllHoldings();
            return Ok(_mapper.Map<IEnumerable<HoldingsReadModel>>(items));            
        }

        // GET
        [HttpGet("{id}", Name = "GetHoldingsById")]  // api/holdings/{id}
        public ActionResult<HoldingsReadModel> GetHoldingsById(int id)
        {
            var item = _repository.ReadHoldingsById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<HoldingsReadModel>(item));
            }

            return NotFound();
        }

        // GET
        [HttpGet("user/{userId}", Name = "GetHoldingsByUserId")]  // api/holdings/user/{userId}
        public ActionResult<IEnumerable<HoldingsReadModel>> GetHoldingsByUserId(int userId)
        {
            var items = _repository.ReadHoldingsByUserId(userId);
            return Ok(_mapper.Map<IEnumerable<HoldingsReadModel>>(items));
        }

        // POST
        [HttpPost]  // api/holdings/{HoldingsReadModel}
        public ActionResult<HoldingsReadModel> CreateHoldings(HoldingsCreateModel holdingsCreateModel)
        {
            var holdingsModel = _mapper.Map<Holdings>(holdingsCreateModel);
            _repository.CreateHolding(holdingsModel);

            var holdingsReadModel = _mapper.Map<HoldingsReadModel>(holdingsModel);
            return CreatedAtRoute(nameof(GetHoldingsById), new { Id = holdingsReadModel.Id }, holdingsReadModel);
        }

        // PUT
        [HttpPut("{id}")]  // api/holdings/{id}
        public ActionResult UpdateHoldings(int id, HoldingsUpdateModel holdingsUpdateModel)
        {
            var holdingsModelFromRepo = _repository.ReadHoldingsById(id);
            if (holdingsModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(holdingsUpdateModel, holdingsModelFromRepo);

            _repository.UpdateHoldings(holdingsModelFromRepo);

            return NoContent();
        }

        // PATCH
        [HttpPatch("{id}")]  // api/holdings/{id}
        public ActionResult PartialHoldingsUpdate(int id, JsonPatchDocument<HoldingsUpdateModel> patchDoc)
        {
            var holdingsModelFromRepo = _repository.ReadHoldingsById(id);
            if (holdingsModelFromRepo == null)
            {
                return NotFound();
            }

            var holdingsToPatch = _mapper.Map<HoldingsUpdateModel>(holdingsModelFromRepo);
            patchDoc.ApplyTo(holdingsToPatch, ModelState);

            if(!TryValidateModel(holdingsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(holdingsToPatch, holdingsModelFromRepo);

            _repository.UpdateHoldings(holdingsModelFromRepo);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]  // api/holdings/{id}
        public ActionResult<Holdings> DeleteHoldings(int id)
        {
            var holdingsModelFromRepo = _repository.ReadHoldingsById(id);
            if (holdingsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteHoldingById(id);

            return NoContent();
        }
    }
}
