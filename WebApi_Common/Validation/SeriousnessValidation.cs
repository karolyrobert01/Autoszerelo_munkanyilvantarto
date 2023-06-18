using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi_Common.Validation
{
    internal class SeriousnessValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string SValue = value.ToString() ?? " ";

			if (Regex.IsMatch(SValue, @"^(?:[1-9]|10)$"))
			{
				return null;
			}

			return new ValidationResult("A Súlyosság formátuma nem megfelelő!", new[] { validationContext.MemberName });
		}
	}
}
