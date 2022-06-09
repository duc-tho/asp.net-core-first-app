using System.ComponentModel.DataAnnotations;

namespace Netpower.Traning._2022.Entities
{
     public abstract class BaseEntity
     {
          [Key]
          public Guid ID { get; set; }
          public DateTimeOffset CreatedAt { get; set; }
          public DateTimeOffset UpdatedAt { get; set; }
     }
}
