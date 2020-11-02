using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using NUnit.Framework;

namespace Altos.Services.Tests
{
    internal static class TestHelpers
    {
        internal static IFluentValidationErrorResult ShouldBeInvalid(this ValidationResult validationResult, int expectedErrorCount)
        {
            Assert.That(validationResult.IsValid, Is.False);
            Assert.That(validationResult.Errors, Has.Count.EqualTo(expectedErrorCount));

            return new FluentValidationErrorResult(validationResult);
        }

        internal static void ShouldBeValid(this ValidationResult validationResult)
        {
            Assert.That(validationResult.IsValid, Is.True);
        }
    }

    internal interface IFluentValidationErrorResult
    {
        IFluentValidationErrorResult ShouldHaveError(int errorIndex, string expectedErrorCode, string expectedErrorMessage);
    }

    internal class FluentValidationErrorResult : IFluentValidationErrorResult
    {
        private readonly ValidationResult validationResult;

        internal FluentValidationErrorResult(ValidationResult validationResult)
        {
            this.validationResult = validationResult;
        }

        public IFluentValidationErrorResult ShouldHaveError(int errorIndex, string expectedErrorCode, string expectedErrorMessage)
        {
            Assert.That(this.validationResult.Errors[errorIndex].ErrorCode, Is.EqualTo(expectedErrorCode));
            Assert.That(this.validationResult.Errors[errorIndex].ErrorMessage, Is.EqualTo(expectedErrorMessage));

            return this;
        }
    }

    internal static class TestExtensions
    {
        internal static DateTime? ToNullableDateTime(this string s)
        {
            if (s == null)
            {
                return null;
            }
            else
            {
                return DateTime.Parse(s);
            }
        }

        internal static Guid? ToNullableGuid(this string s)
        {
            if (s == null)
            {
                return null;
            }
            else
            {
                return new Guid(s);
            }
        }
    }

}
