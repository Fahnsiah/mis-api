using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MISAPI.DAL.Interfaces;
using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MIS_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CouncilTypeController : ControllerBase
    {
        private readonly ICouncilTypeInterface _councilTypeService;

        private readonly IMapper _mapper;

        public CouncilTypeController(
            ICouncilTypeInterface councilTypeService,
            IMapper mapper)
        {
            _councilTypeService = councilTypeService;
            _mapper = mapper;
        }

        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<CouncilTypeResponse>> Get()
        {
            var data = _councilTypeService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<CouncilTypeResponse> Get(int id)
        {
            var data = _councilTypeService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<CouncilTypeResponse> Post([FromBody] CouncilTypeRequest model)
        {
            var data = _councilTypeService.Create(model);
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<CouncilTypeResponse> Put(int id, [FromBody] CouncilTypeRequest model)
        {
            var data = _councilTypeService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _councilTypeService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }    
    
    }
}
