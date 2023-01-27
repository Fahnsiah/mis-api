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
    public class ConsecrationArticleController : ControllerBase
    {
        private readonly IConsecrationArticleInterface _consecrationArticleService;

        private readonly IMapper _mapper;

        public ConsecrationArticleController(
            IConsecrationArticleInterface consecrationArticleService,
            IMapper mapper)
        {
            _consecrationArticleService = consecrationArticleService;
            _mapper = mapper;
        }

        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<ConsecrationArticleResponse>> Get()
        {
            var data = _consecrationArticleService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<ConsecrationArticleResponse> Get(int id)
        {
            var data = _consecrationArticleService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<ConsecrationArticleResponse> Post([FromBody] ConsecrationArticleRequest model)
        {
            var data = _consecrationArticleService.Create(model);
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<ConsecrationArticleResponse> Put(int id, [FromBody] ConsecrationArticleRequest model)
        {
            var data = _consecrationArticleService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _consecrationArticleService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }    
    
    }
}
