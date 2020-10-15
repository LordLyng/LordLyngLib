using System;
using FluentValidation.Resources;
using FluentValidation.Validators;
using LordLyngLib.Core.Extensions;

namespace LordLyngLib.FluentValidation.Validators.Property
{
    public class GuidStringValidator : PropertyValidator
    {
        [Obsolete("This constructor is deprecated and will be removed in FluentValidation 10. Either use the constructor that takes a string, or override the GetDefaultMessageTemplate method.")]
        public GuidStringValidator(IStringSource errorMessageSource) : base(errorMessageSource)
        {
        }

        public GuidStringValidator(string errorMessage) : base(errorMessage)
        {
        }

        public GuidStringValidator() : base("{PropertyName} must be a valid GUID")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var value = context.PropertyValue as string;

            return value.IsValidGuid();
        }
    }
}