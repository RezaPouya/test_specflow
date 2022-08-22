namespace SpecFlow.Domain.Service;

public class Basket
{
    public User User { get; init; }
    public List<Product> Products { get; set; } = new List<Product>();
}