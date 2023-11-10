using System.ComponentModel.DataAnnotations;

namespace WebAppAutores.Validations
{
    //para validaciones personalizadas por atributo, creo la clase y luego puedo usarla
    //como validacion por defecto en el atributo que lo necesite : [FirstLeterUpperCaseAttribute]
    public class FirstLetterUpperCaseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            } 
            
            var firstLetter = value.ToString()[0].ToString();

            if(firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("La primera letra debe estar en mayúscula");
            }

            return ValidationResult.Success;
        }
    }
}
