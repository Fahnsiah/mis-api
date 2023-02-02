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
    public class ConsecrationRequirementController : ControllerBase
    {
        private readonly IConsecrationRequirementInterface _consecrationRequirementService;

        private readonly IMapper _mapper;

        public ConsecrationRequirementController(
            IConsecrationRequirementInterface consecrationRequirementService,
            IMapper mapper)
        {
            _consecrationRequirementService = consecrationRequirementService;
            _mapper = mapper;
        }

        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<ConsecrationRequirementResponse>> Get()
        {
            var data = _consecrationRequirementService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<ConsecrationRequirementResponse> Get(int id)
        {
            var data = _consecrationRequirementService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<ConsecrationRequirementResponse> Post([FromBody] ConsecrationRequirementRequest model)
        {
            var data = _consecrationRequirementService.Create(model);
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<ConsecrationRequirementResponse> Put(int id, [FromBody] ConsecrationRequirementRequest model)
        {
            var data = _consecrationRequirementService.Update(id, model);
            return Ok(data);
        }
    
    }
}
