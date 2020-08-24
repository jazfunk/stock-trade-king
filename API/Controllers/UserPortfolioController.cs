using AutoMapper;
using Core.Entities;
using Infrastructure;
using API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class UserPortfolioController : ControllerBase
    {
        private readonly IUserPortfolioRepo _repository;
        private readonly IMapper _mapper;

        public UserPortfolioController(IUserPortfolioRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET
        [HttpGet] // api/portfolio
        public ActionResult<IEnumerable<PortfolioReadModel>> GetPortfolioItems()
        {
            var items = _repository.ReadPortfolioItems();
            return Ok(_mapper.Map<IEnumerable<PortfolioReadModel>>(items));
        }

        // GET
        [HttpGet("{id}", Name = "GetItemById")]  // api/portfolio/{id}
        public ActionResult<PortfolioReadModel> GetItemById(int id)
        {
            var item = _repository.ReadPortfolioItemById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<PortfolioReadModel>(item));
            }

            return NotFound();
        }

        // GET
        [HttpGet("user/{userId}", Name = "GetItemsByUserId")] // api/portfolio/user/{userId}
        public ActionResult<IEnumerable<PortfolioReadModel>> GetItemsByUserId(int userId)
        {
            var items = _repository.ReadPortfolioItemByUserId(userId);
            return Ok(_mapper.Map<IEnumerable<PortfolioReadModel>>(items));
        }


        //// GET
        //[HttpGet("iex/{userId}", Name = "GetIexByUserId")] // api/portfolio/iex/{symbol}
        //public ActionResult<IEnumerable<IexPortfolioReadModel>> GetIexByUserId(int userId)
        //{

        //    var client = new RestClient("https://cloud.iexapis.com/");
        //    var request = new RestRequest("stable/stock/{symbol}{urlEndPoint}", Method.GET);
        //    string urlEP = "/intraday-prices?chartLast=1&token=pk_05c40d7c1b96480583b08175d1fb4408";
        //    request.AddUrlSegment("symbol", symbol);
        //    request.AddUrlSegment("urlEndPoint", urlEP);

        //    var response = client.Execute(request);

        //    JObject obs = JObject.Parse(response.Content);           


            
            
        //}















        // POST
        [HttpPost]  // api/portfolio/{PortfolioReadModel}
        public ActionResult<PortfolioReadModel> CreateItem(PortfolioCreateModel portfolioCreateModel)
        {
            var itemModel = _mapper.Map<UserPortfolio>(portfolioCreateModel);
            _repository.CreatePortfolioItem(itemModel);

            var portfolioReadModel = _mapper.Map<PortfolioReadModel>(itemModel);
            return CreatedAtRoute(nameof(GetItemById), new { Id = portfolioReadModel.Id }, portfolioReadModel);
        }

        // PUT
        [HttpPut("{id}")]  // api/portfolio/{id}
        public ActionResult UpdateItem(int id, PortfolioUpdateModel portfolioUpdateModel)
        {
            var portfolioModelFromRepo = _repository.ReadPortfolioItemById(id);
            if (portfolioModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(portfolioUpdateModel, portfolioModelFromRepo);

            _repository.UpdatePortfolioItem(portfolioModelFromRepo);

            return NoContent();
        }

        // PATCH
        [HttpPatch("{id}")]  // api/portfolio/{id}
        public ActionResult PartialItemUpdate(int id, JsonPatchDocument<PortfolioUpdateModel> patchDoc)
        {
            var portfolioModelFromRepo = _repository.ReadPortfolioItemById(id);
            if (portfolioModelFromRepo == null)
            {
                return NotFound();
            }

            var itemToPatch = _mapper.Map<PortfolioUpdateModel>(portfolioModelFromRepo);
            patchDoc.ApplyTo(itemToPatch, ModelState);

            if(!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemToPatch, portfolioModelFromRepo);

            _repository.UpdatePortfolioItem(portfolioModelFromRepo);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]  // api/portfolio/{id}
        public ActionResult<UserPortfolio> DeleteItem(int id)
        {
            var portfolioModelFromRepo = _repository.ReadPortfolioItemById(id);
            if (portfolioModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePortfolioItem(id);

            return NoContent();
        }
    }
}
