using Altos.Services.Features.Products.Dtos;
using NUnit.Framework;
using Altos.Domain.Features.Products;

namespace Altos.Services.Tests.Features.Products.Dtos
{
    [TestFixture]
    public class CreateProductCommandValidatorTest
    {
        private CreateProductCommandValidator validator;

        [SetUp]
        public void SetUp()
        {
            this.validator = new CreateProductCommandValidator();
        }

        [TearDown]
        public void TearDown()
        {

        }

        #region Test Methods



        [Test]
        public void Validate_CommandIsNull_ThrowsError()
        {
            // Set up SUT
            CreateProductCommand command = null;

            // Execute SUT
            var validationResult = this.validator.Validate(command);

            // Verify outcome
            validationResult
                .ShouldBeInvalid(1)
                .ShouldHaveError(0, "command_is_null", "Command must be not null"); ;
        }

        [Test]
        public void Validate_TitleIsEmpty_Error()
        {
            // Set up SUT
            var command = CreateCommand();
            command.Title = string.Empty;

            // Execute SUT
            var validationResult = this.validator.Validate(command);

            // Verify outcome
            validationResult
                .ShouldBeInvalid(1)
                .ShouldHaveError(0, "title_is_empty", "Title must be set");
        }

        #endregion

        #region Private Methods

        private static CreateProductCommand CreateCommand()
        {
            return new CreateProductCommand
            {
                Title = "Test Title",
                ProductType = ProductType.InstantiableProduct,
                ProductTimeZoneId = "Time zone id"
            };
        }

        #endregion
    }
}
