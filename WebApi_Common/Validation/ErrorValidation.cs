using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Validation
{
    internal class ErrorValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string erValue = value.ToString() ?? " ";

			if (!string.IsNullOrWhiteSpace(erValue))
			{
				return null;
			}

			return new ValidationResult("A hibaleírás mező kitöltése kötelező!", new[] { validationContext.MemberName });
		}
	}
}
