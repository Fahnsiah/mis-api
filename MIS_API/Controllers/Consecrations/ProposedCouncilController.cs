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
    public class ProposedCouncilController : ControllerBase
    {
        private readonly IProposedCouncilInterface _proposedCouncilService;
        private readonly IMapper _mapper;

        public ProposedCouncilController(
            IProposedCouncilInterface proposedCouncilService,
            IMapper mapper)
        {
            this._proposedCouncilService = proposedCouncilService;
            _mapper = mapper;
        }
        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<ProposedCouncilResponse>> Get()
        {
            var data = _proposedCouncilService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<ProposedCouncilResponse> Get(int id)
        {
            var data = _proposedCouncilService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<ProposedCouncilResponse> Post([FromBody] ProposedCouncilRequest model)
        {
            var data = _proposedCouncilService.Create(model);            
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<ProposedCouncilResponse> Put(int id, [FromBody] ProposedCouncilRequest model)
        {
            var data = _proposedCouncilService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _proposedCouncilService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }
    }
}
