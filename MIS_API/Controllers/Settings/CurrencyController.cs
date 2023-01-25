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
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyInterface _currencyService;

        private readonly IMapper _mapper;

        public CurrencyController(
            ICurrencyInterface currencyService,
            IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<CurrencyResponse>> Get()
        {
            var data = _currencyService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<CurrencyResponse> Get(int id)
        {
            var data = _currencyService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<CurrencyResponse> Post([FromBody] CurrencyRequest model)
        {
            var data = _currencyService.Create(model);
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<CurrencyResponse> Put(int id, [FromBody] CurrencyRequest model)
        {
            var data = _currencyService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _currencyService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }    
    
    }
}
