using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MISAPI.DAL.Interfaces;
using MISAPI.DataModel.ViewModels.RolePermissions;
using MISAPI.DataModel.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MIS_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RitualController : ControllerBase
    {
        private readonly IRitualInterface _ritualService;

        private readonly IMapper _mapper;

        public RitualController(
            IRitualInterface ritualService,
            IMapper mapper)
        {
            _ritualService = ritualService;
            _mapper = mapper;
        }

        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<RitualResponse>> Get()
        {
            var data = _ritualService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<RitualResponse> Get(int id)
        {
            var data = _ritualService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<RitualResponse> Post([FromBody] RitualRequest model)
        {
            var data = _ritualService.Create(model);
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<RitualResponse> Put(int id, [FromBody] RitualRequest model)
        {
            var data = _ritualService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ritualService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }    
    
    }
}
