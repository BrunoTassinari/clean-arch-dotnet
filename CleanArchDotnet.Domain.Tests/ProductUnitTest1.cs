using CleanArchDotnet.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchDotnet.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValid()
        {
            Action action = () => new Product("Product name", "Product description", 10, 1, "product image");
            action.Should()
                .NotThrow<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateProduct_WithNullNameValue_ResultObjectInvalid()
        {
            Action action = () => new Product("", "Product description", 10, 1, "product image");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateProduct_WithShortNameValue_ResultObjectInvalid()
        {
            Action action = () => new Product("Pr", "Product description", 10, 1, "product image");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name must have at least 3 characters");
        }

        [Fact]
        public void CreateProduct_WithNullDescriptionValue_ResultObjectInvalid()
        {
            Action action = () => new Product("Product name", "", 10, 1, "product image");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact]
        public void CreateProduct_WithShortDescriptionValue_ResultObjectInvalid()
        {
            Action action = () => new Product("Product name", "Prod", 10, 1, "product image");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description must have at least 5 characters");
        }

        [Fact]
        public void CreateProduct_WithInvalidPriceValue_ResultObjectInvalid()
        {
            Action action = () => new Product("Product name", "Product description", -10, 1, "product image");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price. Price must be greater than zero");
        }

        [Fact]
        public void CreateProduct_WithInvalidStockValue_ResultObjectInvalid()
        {
            Action action = () => new Product("Product name", "Product description", 10, -1, "product image");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock. Stock must be greater than zero");
        }

        [Fact]
        public void CreateProduct_WithNullImageValue_ResultObjectInvalid()
        {
            Action action = () => new Product("Product name", "Product description", 10, 1, "");
            action.Should()
                .Throw<CleanArchDotnet.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image. Image is required");
        }

    }
}
