using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApi_Common.Validation
{
	internal class WorkDetailsValidation : ValidationAttribute
    {
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string detValue = value.ToString() ?? " ";

			if (!string.IsNullOrWhiteSpace(detValue))
			{
				return null;
			}

			return new ValidationResult("A Munkaleírás mező kitöltése kötelező!", new[] { validationContext.MemberName });
		}
	}
}
