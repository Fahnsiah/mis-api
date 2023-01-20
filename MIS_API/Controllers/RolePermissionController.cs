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

        [HttpPost("add-remove")]
        public void AddRemoveAll(IEnumerable<RoleAddRemoveRequest> model)
        {
            _rolePermissionService.AddRemoveAll(model);
            //return Ok(data);
        }

        [HttpGet("operations")]
        public ActionResult<IEnumerable<OperationResponse>> GetOperations(string id)
        {
            var data = _rolePermissionService.GetOperations(id);
            return Ok(data);
        }


        [HttpGet("subMenus")]
        public ActionResult<IEnumerable<MenuResponse>> GetSubMenus()
        {
            var data = _rolePermissionService.GetSubMenus();
            return Ok(data);
        }


        [HttpGet("menus")]
        public ActionResult<IEnumerable<MenuResponse>> GetMenus()
        {
            var data = _rolePermissionService.GetMenus();
            return Ok(data);
        }

        [HttpGet("module-operation")]
        public ActionResult<IEnumerable<OperationResponse>> GetMenuOperations()
        {
            var data = _rolePermissionService.GetMenuOperations();
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

        [HttpGet("update-admin-roles")]
        public IActionResult UpdateAdminRoles()
        {
            if (_rolePermissionService.UpdateAdminRoles())
            {
                return Ok(new { message = "All existing permissions in the system have been assigned to admin." });
            }
            else
            {
                return Ok(new { message = "Error occurred while updating the admin roles" });
            }
           
        }
    }
}
