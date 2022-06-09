using Microsoft.EntityFrameworkCore;
using Netpower.Traning._2022.Entities;

namespace Netpower.Traning._2022.Repositories;
public class DatabaseContext : DbContext
{
     public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

     public DbSet<User> User { get; set; }
     public DbSet<Role> Role { get; set; }
}
