using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MISAPI.DAL.Interfaces;
using MISAPI.DataModel.ViewModels.RolePermissions;
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
    public class RoleController : ControllerBase
    {
        private readonly IRoleInterface _roleService;
        private readonly IMapper _mapper;

        public RoleController(
            IRoleInterface roleService,
            IMapper mapper)
        {
            this._roleService = roleService;
            _mapper = mapper;
        }
        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<RoleResponse>> Get()
        {
            var data = _roleService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<RoleResponse> Get(int id)
        {
            var data = _roleService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<RoleResponse> Post([FromBody] RoleRequest model)
        {
            var data = _roleService.Create(model);            
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<RoleResponse> Put(int id, [FromBody] RoleRequest model)
        {
            var data = _roleService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roleService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }
    }
}
