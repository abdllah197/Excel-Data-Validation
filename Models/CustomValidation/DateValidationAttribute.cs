using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CustomValidation
{
    public class DateValidationAttribute:ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "{0} is not a valid date";
        

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                string? Value = value.ToString();

                if (DateTime.TryParse(Value, out DateTime dateTime))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(string.Format(DefaultErrorMessage, validationContext.DisplayName));
                }
            }

            return null;
        }
    }
}
