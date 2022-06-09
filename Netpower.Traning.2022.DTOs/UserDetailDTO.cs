using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Traning._2022.DTOs
{
     public class UserDetailDTO : BaseDTO
     {
          public string Fullname { get; set; }
          public int? Age { get; set; }
          public string Email { get; set; }
          public string? Phone { get; set; }
          public string Password { get; set; }
          public Guid RoleID { get; set; }

     }
}
