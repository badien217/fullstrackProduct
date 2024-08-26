using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Register
{
    public class RegisterClientValidate : AbstractValidator<RegisterClientRequest>
    {
        public RegisterClientValidate() {
            RuleFor(x => x.Email).EmailAddress().WithName("email error");
            RuleFor(x => x.Phone).NotEmpty().WithName("phone error");
            RuleFor(x => x.Password).Must(IsValidPassword).WithName("password");
        }
        public static bool IsValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(password);
        }
    }
}
