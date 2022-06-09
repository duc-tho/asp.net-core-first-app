using System.ComponentModel.DataAnnotations.Schema;

namespace Netpower.Traning._2022.Entities;

public class User : BaseEntity
{
     public string? Fullname { get; set; }
     public int? Age { get; set; }
     public string? Email { get; set; }
     public string? Phone { get; set; }
     public string? Password{ get; set; }
     public Guid RoleID { get; set; }

     [ForeignKey("RoleID")]
     public Role? Role { get; set; }
}
