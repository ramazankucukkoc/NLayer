using AutoMapper.Internal.Mappers;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Service.DtoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		public UserService(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<CustomResponseDto<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
		{
			var user= new AppUser { Email=createUserDto.Email,UserName=createUserDto.UserName,PhoneNumber=createUserDto.PhoneNumber};
			var result=await _userManager.CreateAsync(user,createUserDto.Password);

			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(x => x.Description).ToList();
				return CustomResponseDto<UserDto>.Fail(400, errors);
			}
			return CustomResponseDto<UserDto>.Success(200,ObjectMapper.Mapper.Map<UserDto>(user));
		}

		public async Task<CustomResponseDto<UserDto>> GetUserByEmailAsync(string email)
		{
			var user =await _userManager.FindByEmailAsync(email);
			if (user == null)
			{
				return CustomResponseDto<UserDto>.Fail(404, "Email Bulunumadı");
			}
			return CustomResponseDto<UserDto>.Success(200, ObjectMapper.Mapper.Map<UserDto>(user));
			
		}

		public async Task<CustomResponseDto<UserDto>> GetUserByUserNameAsync(string userName)
		{
			var user =await _userManager.FindByNameAsync(userName);
			if (user==null)
			{
				return CustomResponseDto<UserDto>.Fail( 404, "UserName not found");
			}
			return CustomResponseDto<UserDto>.Success(200,ObjectMapper.Mapper.Map<UserDto>(user));
		}

		//public async Task<CustomResponseDto<UserDto>> LogIn(LoginDto userLogin)
		//{
		//	var user = await _userManager.FindByEmailAsync(userLogin.Email);
		//	if (user == null)
		//	{
		//		if (await _userManager.IsLockedOutAsync(user))
		//		{
		//			return CustomResponseDto<UserDto>.Fail(404, "Hesabınız bir süreliğine kilitlenmiştir.Lütfen daha sonra tekrar deneyiniz");
		//		}
		//		await _signInManager.SignOutAsync();

		//	}

		//}
	}
}
