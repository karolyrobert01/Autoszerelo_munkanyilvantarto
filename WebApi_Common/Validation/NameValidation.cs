using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApi_Common.Validation
{
    public class NameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string nameValue = value.ToString() ?? " ";

            if (!string.IsNullOrWhiteSpace(nameValue))
            {
                if (Regex.IsMatch(nameValue, @"^[A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+ [A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+$"))
                {
                    return null;
                }
                else
                {
                    return new ValidationResult("A név formátuma nem megfelelő!", new[] { validationContext.MemberName });
                }
            }

            return new ValidationResult("A név mező kitöltése kötelező!", new[] { validationContext.MemberName });
        }
    }
}
