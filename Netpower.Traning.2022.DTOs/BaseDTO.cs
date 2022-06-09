namespace Netpower.Traning._2022.DTOs
{
     public abstract class BaseDTO
     {
          public Guid ID { get; set; }
          public DateTimeOffset CreatedAt { get; set; }
          public DateTimeOffset UpdatedAt { get; set; }
     }
}
