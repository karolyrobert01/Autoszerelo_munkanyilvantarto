using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace WebApi_Common.Validation
{
    public class IDValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string RSZValue = value.ToString() ?? " ";

            if (Regex.IsMatch(RSZValue, @"^[A-Z]{3}-\d{3}$"))
            {
                return null;
            }

            return new ValidationResult("A Rendszám formátuma nem megfelelő!", new[] { validationContext.MemberName });
        }
    }
}
