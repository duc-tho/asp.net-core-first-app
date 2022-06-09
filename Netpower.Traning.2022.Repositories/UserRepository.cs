using Netpower.Traning._2022.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Traning._2022.Repositories
{
     public class UserRepository : BaseRepository<User>
     {
          public UserRepository(DatabaseContext context) : base(context) { }
     }
}
