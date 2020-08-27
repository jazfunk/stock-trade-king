using AutoMapper;
using Core.Entities;
using Infrastructure;
using API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/ledger")]
    [ApiController]

    public class LedgerController : ControllerBase
    {
        private readonly ILedgerRepo _repository;
        private readonly IMapper _mapper;

        public LedgerController(ILedgerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET
        [HttpGet]  // api/ledger
        public ActionResult<IEnumerable<LedgerReadModel>> GetAllLedgerItems()
        {
            var items = _repository.ReadAllLedgerItems();
            return Ok(_mapper.Map<IEnumerable<LedgerReadModel>>(items));
        }

        // GET
        [HttpGet("{id}", Name = "GetLedgerById")]  // api/ledger{id}
        public ActionResult<LedgerReadModel> GetLedgerById(int id)
        {
            var item = _repository.ReadLedgerById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<LedgerReadModel>(item));
            }

            return NotFound();
        }

        // GET
        [HttpGet("holdings/{holdingsId}", Name = "GetLedgerByHoldingsId")]  // api/ledger/holdings/{holdingsId}
        public ActionResult<IEnumerable<LedgerReadModel>> GetLedgerByHoldingsId(int holdingsId)
        {
            var items = _repository.ReadLedgerByHoldingsId(holdingsId);
            return Ok(_mapper.Map<IEnumerable<LedgerReadModel>>(items));
        }

        // POST
        [HttpPost]  // api/ledger/{LedgerReadModel}
        public ActionResult<LedgerReadModel> CreateLedger(LedgerCreateModel ledgerCreateModel)
        {
            var ledgerModel = _mapper.Map<Ledger>(ledgerCreateModel);
            _repository.CreateLedger(ledgerModel);

            var ledgerReadModel = _mapper.Map<LedgerReadModel>(ledgerModel);
            return CreatedAtRoute(nameof(GetLedgerById), new { Id = ledgerReadModel.Id }, ledgerReadModel);
        }

        // PUT
        [HttpPut("{id}")]  // api/ledger{id}
        public ActionResult UpdateLedger(int id, LedgerUpdateModel ledgerUpdateModel)
        {
            var ledgerModelFromRepo = _repository.ReadLedgerById(id);
            if (ledgerModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(ledgerUpdateModel, ledgerModelFromRepo);

            _repository.UpdateLedger(ledgerModelFromRepo);

            return NoContent();
        }

        // PATCH
        [HttpPatch("{id}")]  // api/ledger/{id}
        public ActionResult PartialLedgerUpdate(int id, JsonPatchDocument<LedgerUpdateModel> patchDoc)
        {
            var ledgerModelFromRepo = _repository.ReadLedgerById(id);
            if (ledgerModelFromRepo == null)
            {
                return NotFound();
            }

            var ledgerToPatch = _mapper.Map<LedgerUpdateModel>(ledgerModelFromRepo);
            patchDoc.ApplyTo(ledgerToPatch, ModelState);

            if (!TryValidateModel(ledgerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ledgerToPatch, ledgerModelFromRepo);

            _repository.UpdateLedger(ledgerModelFromRepo);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]  // api/ledger/{id}
        public ActionResult<Ledger> DeleteLedger(int id)
        {
            var ledgerModelFromRepo = _repository.ReadLedgerById(id);
            if(ledgerModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteLedgerById(id);

            return NoContent();
        }
        
    }
}
