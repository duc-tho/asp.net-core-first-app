using Netpower.Traning._2022.Core;
using Netpower.Traning._2022.DTOs;
using Netpower.Traning._2022.Entities;
using Netpower.Traning._2022.Repositories;

namespace Netpower.Traning._2022.Services
{
     public class UserService : BaseService
     {
          private readonly UserRepository _userRepository;
          private readonly RoleRepository _roleRepository;

          public UserService
          (
               UserRepository userRepository,
               RoleRepository roleRepository
          )
          {
               _userRepository = userRepository;
               _roleRepository = roleRepository;
          }

          public IEnumerable<UserDTO> GetUsers(int limit, int page)
          {
               IEnumerable<UserDTO> users = _userRepository.Get(limit, page).Result
                    .Select(user => new UserDTO
                    {
                         ID = user.ID,
                         Age = user.Age,
                         Email = user.Email,
                         Fullname = user.Fullname,
                         Phone = user.Phone,
                         RoleID = user.RoleID,
                         CreatedAt = user.CreatedAt,
                         UpdatedAt = user.UpdatedAt,
                    });

               return users;
          }

          public Task<User> CreateUser(UserDetailDTO user)
          {
               ValueTask<Role> role = _roleRepository.Get(user.RoleID);

               if (role.Result == null) throw new Exception("Role is not exitst");

               User newUser = new User
               {
                    ID = user.ID,
                    Fullname = user.Fullname,
                    Email = user.Email,
                    Age = user.Age,
                    Phone = user.Phone,
                    RoleID = user.RoleID,
                    Password = HashPassword.Hash(user.Password),
                    CreatedAt = DateTimeOffset.Now,
               };

               Task<User> result = _userRepository.Insert(newUser);

               SendEmailToAdmin("Create User", user.ID.ToString() + " create success.");

               return result;
          }

          public Task UpdateUser(UserDetailDTO user)
          {
               ValueTask<User> findUser = _userRepository.Get(user.ID);
               User currentUser = findUser.Result;

               if (currentUser == null) throw new Exception("User is not exitst");

               currentUser.Fullname = user.Fullname;
               currentUser.Email = user.Email;
               currentUser.Age = user.Age;
               currentUser.Phone = user.Phone;
               currentUser.RoleID = user.RoleID;
               currentUser.Password = HashPassword.Hash(user.Password);
               currentUser.UpdatedAt = DateTimeOffset.Now;

               Task<int> result = _userRepository.Update(currentUser);

               SendEmailToAdmin("Update User", user.ID.ToString() + " update success.");

               return result;
          }

          public Task DeleteUser(Guid ID)
          {
               ValueTask<User> findUser = _userRepository.Get(ID);

               if (findUser.Result == null) throw new Exception("User is not exitst");

               Task<int> result = _userRepository.Delete(findUser.Result);

               SendEmailToAdmin("Delete User", ID.ToString() + " delete success.");

               return result;
          }

     }
}
