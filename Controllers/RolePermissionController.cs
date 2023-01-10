using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MIS_API.Interface;
using MIS_API.Models.RolePermissions;
using MIS_API.Models.Roles;
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
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionInterface _rolePermissionService;
        private readonly IMapper _mapper;

        public RolePermissionController(
            IRolePermissionInterface rolePermissionService,
            IMapper mapper)
        {
            this._rolePermissionService = rolePermissionService;
            _mapper = mapper;
        }

        [HttpGet("actions")]
        public ActionResult<IEnumerable<ModuleResponse>> GetActions()
        {
            var data = _rolePermissionService.GetActions();
            return Ok(data);
        }


        [HttpGet("tasks")]
        public ActionResult<IEnumerable<ModuleResponse>> GetTasks()
        {
            var data = _rolePermissionService.GetTasks();
            return Ok(data);
        }


        [HttpGet("modules")]
        public ActionResult<IEnumerable<ModuleResponse>> GetModules()
        {
            var data = _rolePermissionService.GetModules();
            return Ok(data);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RolePermissionResponse>> Get()
        {
            var data = _rolePermissionService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<RolePermissionResponse> Get(int id)
        {
            var data = _rolePermissionService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<RolePermissionResponse> Post([FromBody] RolePermissionRequest model)
        {
            var data = _rolePermissionService.Create(model);            
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<RolePermissionResponse> Put(int id, [FromBody] RolePermissionRequest model)
        {
            var data = _rolePermissionService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _rolePermissionService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }

        [HttpGet("admin-roles")]
        public IActionResult AddAdminRoles()
        {
            _rolePermissionService.AddAdminRoles();
            return Ok(new { message = "All existing permissions in the system have been assigned to admin." });
        }
    }
}
