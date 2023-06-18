using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi_Common.Validation
{
    internal class YearValidation : ValidationAttribute
    {
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string YEARValue = value.ToString() ?? " ";

			if (Regex.IsMatch(YEARValue, @"^(19[0-9]{2}|20[0-2][0-3])$"))
			{
				return null;
			}

			return new ValidationResult("A Rendszám formátuma nem megfelelő!", new[] { validationContext.MemberName });
		}
	}
}
