namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; }
}

public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

    // Construtor protegido garantindo integridade das regras
    public Product(string name, decimal price)
    {
        UpdateDetails(name, price);
        IsActive = true;
    }

    public void UpdateDetails(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do produto é obrigatório.", nameof(name));
        
        if (price <= 0)
            throw new ArgumentOutOfRangeException(nameof(price), "O preço deve ser superior a zero.");

        Name = name;
        Price = price;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate() => IsActive = false;
}