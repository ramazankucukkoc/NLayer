using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.FluentValidation
{
	public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
	{
		public CreateUserDtoValidator()
		{
			RuleFor(x => x.UserName).NotNull().WithMessage("Ramo Baba UserName is required")
				.NotEmpty().WithMessage("Ramo Baba UserName is required");

			RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Ramo Baba Tel No is required");

			RuleFor(x => x.Email).NotNull().WithMessage("Ramo Baba EMAİL is required")
				.NotEmpty().WithMessage("Ramo Baba UserName is required")
				.EmailAddress().WithMessage("Email adresiniz email formatınmda değil");

			RuleFor(x => x.Password).NotNull().WithMessage("Password is required")
				.NotEmpty().WithMessage("Password is required");


        }
	}
}
