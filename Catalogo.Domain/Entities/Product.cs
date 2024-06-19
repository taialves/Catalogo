using Catalogo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Entities;

public sealed class Product : Entity
{
    public string Code { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string? Supplier { get; private set; }
    public int InitialStock { get; private set; } = 1;
    public DateTime ExpiryDate { get; private set; }
    public int CategoryId { get; set; }

    // Propriedade de navegacao para Category
    public Category? Category { get; set; }

    // Propriedade de navegacao para Stock
    public Stock Stock { get; set; }
    
    public Product(string code, string description, decimal price, string supplier, int initialStock, DateTime expiryDate)
    {
        ValidateDomain(code, description, price, supplier, initialStock, expiryDate);
    }
    public Product(int id, string code, string description, decimal price, string supplier, int initialStock, DateTime expiryDate)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(code, description, price, supplier, initialStock, expiryDate);
    }
    public void update( string code, string description, decimal price, string supplier, int initialStock, DateTime expiryDate, int categoryId)
    {
        ValidateDomain(code, description, price, supplier, initialStock, expiryDate);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string code, string description, decimal price, string supplier, int initialStock, DateTime expiryDate)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(code), "Invalid name. Name is null or invalid.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(supplier), "Invalid supplier. Supplier is required.");

        DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters.");
        DomainExceptionValidation.When(supplier?.Length < 3, "Invalid supplier, too short, minimum 3 characters.");

        DomainExceptionValidation.When(price <= 0, "Invalid price value.");
        DomainExceptionValidation.When(initialStock < 0, "Invalid initial stock value.");

        DomainExceptionValidation.When(expiryDate < DateTime.Now, "Invalid expiry date value.");

        Code = code;
        Description = description;
        Price = price;
        Supplier = supplier;
        InitialStock = initialStock;
        ExpiryDate = expiryDate;
    }

}

