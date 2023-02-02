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
    public class CouncilController : ControllerBase
    {
        private readonly ICouncilInterface _councilService;

        private readonly IMapper _mapper;

        public CouncilController(
            ICouncilInterface councilService,
            IMapper mapper)
        {
            _councilService = councilService;
            _mapper = mapper;
        }

        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<CouncilResponse>> Get()
        {
            var data = _councilService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<CouncilResponse> Get(int id)
        {
            var data = _councilService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<CouncilResponse> Post([FromBody] CouncilRequest model)
        {
            var data = _councilService.Create(model);
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<CouncilResponse> Put(int id, [FromBody] CouncilRequest model)
        {
            var data = _councilService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _councilService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }    
    
    }
}
