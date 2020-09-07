using System.Collections.Generic;
using System.Threading.Tasks;
using PortalAPI.Dtos;

namespace PortalAPI.Data
{

 public interface IUserRepository
 {

     Task<UserResponseReadDto> RegisterUserAsync(UserRegisterCreateDto model);

       Task<UserResponseReadDto> LoginUserAsync(UserLoginDto model);

 }

}