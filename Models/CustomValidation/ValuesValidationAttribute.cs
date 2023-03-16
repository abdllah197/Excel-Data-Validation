using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CustomValidation
{
    public class ValuesValidationAttribute : ValidationAttribute
    {

        public string[] Values { get; set; }
        public string DefaultErrorMessage { get; set; } = "{0} is not equal to the values";        
        public ValuesValidationAttribute(params string[] values) 
        { 
            Values = values; 
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                string? Value = value.ToString();

                if (Values.Contains(Value))
                {
                    return ValidationResult.Success;
                }
                else
                {

                    List<string> Parameters = Values.ToList();
                    Parameters.Insert(0, validationContext.DisplayName);
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, Parameters.ToArray()));
                }
            }

            return null;
        }
    }
}
