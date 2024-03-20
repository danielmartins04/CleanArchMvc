using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Enitities;

public sealed class Category : Entity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");

        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum are 3 characters");

        Name = name;
    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    public ICollection<Product> Products { get; }
}
