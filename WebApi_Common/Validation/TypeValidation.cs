using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi_Common.Validation
{
    internal class TypeValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string TYPEValue = value.ToString() ?? " ";

			if (!string.IsNullOrWhiteSpace(TYPEValue))
			{
				return null;
			}

			return new ValidationResult("A típus mező kitöltése kötelező!", new[] { validationContext.MemberName });
		}
	}
}
