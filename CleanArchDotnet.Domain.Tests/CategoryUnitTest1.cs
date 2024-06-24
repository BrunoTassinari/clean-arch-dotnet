using CleanArchDotnet.Domain.Entities;
using FluentAssertions;

namespace CleanArchDotnet.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValid()
        {
            Action action = () => new Category("Category name");
            action.Should()
                .NotThrow<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateCategory_WithNullNameValue_ResultObjectInvalid()
        {
            Action action = () => new Category("");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithShortNameValue_ResultObjectInvalid()
        {
            Action action = () => new Category("Ca");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name must have at least 3 characters");
        }

    }
}