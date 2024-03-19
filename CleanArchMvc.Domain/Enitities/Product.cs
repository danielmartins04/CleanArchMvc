using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Enitities;

public sealed class Product : Entity
{
    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Invalid id");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, mininum 3 characters");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
        DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters");
        DomainExceptionValidation.When(price < 0, "Invalid price");
        DomainExceptionValidation.When(stock < 0, "Invalid stock");
        DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too large, maximum 250 characters");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public int CategoryId { get; private set; }
    public Category Category { get; }
}
