using Microsoft.AspNetCore.Mvc;
using Netpower.Traning._2022.DTOs;
using Netpower.Traning._2022.Entities;
using Netpower.Traning._2022.Services;

namespace Netpower.Traning._2022.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class RoleController : ControllerBase
     {
          private readonly RoleService _roleService;

          public RoleController(RoleService roleService)
          {
               this._roleService = roleService;
          }

          [HttpGet]
          public IEnumerable<RoleDTO> GetRoles(int limit, int page)
          {
               return _roleService.GetRoles(limit, page);
          }

          [HttpPost]
          public ActionResult<Role> CreateRole(RoleDTO role)
          {
               Task<Role> CreatedRole = _roleService.CreateRole(role);
               return Ok(CreatedRole.Result.ID);
          }

          [HttpPut]
          public ActionResult UpdateRole(RoleDTO role)
          {
               _roleService.UpdateRole(role);
               return Ok("Update role success");
          }

          [HttpDelete]
          public ActionResult DeleteRole(Guid ID)
          {
               _roleService.DeleteRole(ID);
               return Ok("Delete role success");
          }
     }
}
