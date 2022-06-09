namespace Netpower.Traning._2022.Entities;

public class Role : BaseEntity
{
     public string? Name { get; set; }

     public ICollection<User>? User { get; set; }
}