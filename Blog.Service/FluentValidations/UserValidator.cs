using Blog.Entity.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()     
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("Ýsim");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("Soyisim");
            
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(11) 
                .WithName("Telefon Numarasý");

           
        }
    }
}
