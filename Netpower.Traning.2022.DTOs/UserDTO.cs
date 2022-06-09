namespace Netpower.Traning._2022.DTOs;

public class UserDTO : BaseDTO
{
     public string? Fullname { get; set; }
     public int? Age { get; set; }
     public string? Email { get; set; }
     public string? Phone { get; set; }
     public Guid RoleID { get; set; }
}
