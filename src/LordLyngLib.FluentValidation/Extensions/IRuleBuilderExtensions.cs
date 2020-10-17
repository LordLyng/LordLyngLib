using FluentValidation;
using LordLyngLib.FluentValidation.Validators.Property;

namespace LordLyngLib.FluentValidation.Extensions
{
    public static class IRuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeValidGuid<T> (this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator (new GuidStringValidator ());
        }
    }
}
