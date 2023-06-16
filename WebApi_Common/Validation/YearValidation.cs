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
			string ssnValue = value.ToString() ?? " ";

			if (Regex.IsMatch(ssnValue, @"^\d{3}-\s{3}$"))
			{
				return null;
			}

			return new ValidationResult("A Rendszám formátuma nem megfelelő!", new[] { validationContext.MemberName });
		}
	}
}
