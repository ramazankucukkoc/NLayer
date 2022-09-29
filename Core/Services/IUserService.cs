using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<CustomResponseDto<UserDto>>CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResponseDto<UserDto>> GetUserByUserNameAsync(string userName);

        Task<CustomResponseDto<UserDto>>GetUserByEmailAsync(string email);
        //Task<CustomResponseDto<UserDto>>GetUserByPhoneNumberAsync(string phoneNumber);


        //Task<CustomResponseDto<UserDto>> LogIn(LoginDto loginDto);

        //Task<Response<UserDto>>GetAll();
    }
}
