using Geent.Application.DTOs.Request;
using Geent.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.Interface.Service
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegisterRequestDto userRegisterDto);
        Task VerifyUserAsync(string email, string code);
        Task<UserResponseDto> GetCurrentUserAsync(string email);


    }
}
