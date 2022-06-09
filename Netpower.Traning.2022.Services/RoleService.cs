using Netpower.Traning._2022.Core;
using Netpower.Traning._2022.DTOs;
using Netpower.Traning._2022.Entities;
using Netpower.Traning._2022.Repositories;

namespace Netpower.Traning._2022.Services
{
     public class RoleService : BaseService
     {
          private readonly RoleRepository _roleRepository;

          public RoleService(RoleRepository roleRepository)
          {
               _roleRepository = roleRepository;
          }

          public IEnumerable<RoleDTO> GetRoles(int limit, int page)
          {
               IEnumerable<RoleDTO> roles = _roleRepository.Get(limit, page).Result
                    .Select(role => new RoleDTO
                    {
                         ID = role.ID,
                         Name = role.Name,
                         CreatedAt = role.CreatedAt,
                         UpdatedAt = role.UpdatedAt
                    });

               return roles;
          }

          public Task<Role> CreateRole(RoleDTO role)
          {
               Role newRole = new Role
               {
                    ID = role.ID,
                    Name = role.Name,
                    CreatedAt = DateTimeOffset.Now,
               };

               Task<Role> result = _roleRepository.Insert(newRole);
               SendEmailToAdmin("Create Role", role.ID.ToString() + " create success.");

               return result;
          }

          public Task UpdateRole(RoleDTO role)
          {
               ValueTask<Role> findRole = _roleRepository.Get(role.ID);
               Role currentRole = findRole.Result;

               if (currentRole == null) throw new Exception("Role is not exitst");

               currentRole.Name = role.Name;
               currentRole.UpdatedAt = DateTimeOffset.Now;

               Task<int> result = _roleRepository.Update(currentRole);
               SendEmailToAdmin("Update Role", role.ID.ToString() + " update success.");

               return result;
          }

          public Task DeleteRole(Guid ID)
          {
               ValueTask<Role> findRole = _roleRepository.Get(ID);

               if (findRole.Result == null) throw new Exception("Role is not exitst");

               Task<int> result = _roleRepository.Delete(findRole.Result);
               SendEmailToAdmin("Delete Role", ID.ToString() + " delete success.");

               return result;
          }
     }
}
