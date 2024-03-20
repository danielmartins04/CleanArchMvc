using CleanArchMvc.Domain.Enitities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Category with valid state")]
    public void CreateCategory_WithValidParameters_ShouldReturnValidState()
    {
        var category = () => new Category(1, "category name");
        category.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Category with negative id value")]
    public void CreateCategory_WithNegativeIdValue_ShouldThrowDomainExceptionInvalidId()
    {
        var category = () => new Category(-1, "category name");
        category.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Category with short name")]
    public void CreateCategory_WithShortNameValue_ShouldThrowDomainExceptionShortName()
    {
        var category = () => new Category(1, "ca");
        category.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum are 3 characters");
    }

    [Fact(DisplayName = "Category missing name value")]
    public void CreateCategory_MissingNameValue_ShouldThrowDomainExceptionRequiredName()
    {
        var category = () => new Category(1, "");
        category.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required");
    }
}