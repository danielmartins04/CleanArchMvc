using CleanArchMvc.Domain.Enitities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest
{
    [Fact(DisplayName = "Product with valid state")]
    public void CreateProduct_WithValidParameters_ShouldReturnValidState()
    {
        var product = () => new Product(1, "product name", "product desc", 9.99m, 99, "product img");
        product.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Product with invalid id")]
    public void CreateProduct_WithNegativeIdValue_ShouldReturnDomainExceptionInvalidId()
    {
        var product = () => new Product(-1, "product name", "product desc", 9.99m, 99, "product img");
        product.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid id");
    }

    [Fact(DisplayName = "Product with short name value")]
    public void CreateProduct_WithShortNameValue_ShouldReturnDomainExceptionShortName()
    {
        var product = () => new Product(1, "pr", "product desc", 9.99m, 99, "product img");
        product.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, mininum 3 characters");
    }

    [Theory(DisplayName = "Product with negative stock value")]
    [InlineData(-5)]
    public void CreateProduct_WithInvalidStockValue_ShouldReturnDomainExceptionStockNegativeValue(int value)
    {
        var product = () => new Product(1, "product name", "product desc", 9.99m, value, "product img");
        product.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock");
    }
}
