using Microsoft.AspNetCore.Mvc;
using Netpower.Traning._2022.DTOs;
using Netpower.Traning._2022.Entities;
using Netpower.Traning._2022.Services;

namespace Netpower.Traning._2022.API.Controllers
{
     [ApiController]
     [Route("api/[Controller]")]
     public class UserController : Controller
     {
          private readonly UserService _userService;
          
          public UserController(UserService userService)
          {
               this._userService = userService;
          }

          [HttpGet]
          public IEnumerable<UserDTO> GetUsers(int limit, int page)
          {
               return _userService.GetUsers(limit, page);
          }

          [HttpPost]
          public ActionResult<User> CreateUser(UserDetailDTO user)
          {
               Task<User> CreatedUser = _userService.CreateUser(user);
               return Ok(CreatedUser.Result.ID);
          }

          [HttpPut]
          public ActionResult UpdateUser(UserDetailDTO user)
          {
               _userService.UpdateUser(user);
               return Ok("Update user success");
          }

          [HttpDelete]
          public ActionResult DeleteUser(Guid ID)
          {
               _userService.DeleteUser(ID);
               return Ok("Delete user success");
          }
     }
}
