using System.ComponentModel.DataAnnotations;

namespace MemeGame.Common.Extensions
{
    public static class ValidatorExtensions
    {
        public static void Validate(this object instance)
        {
            Validator.ValidateObject(instance, new ValidationContext(instance));
        }
    }
}
