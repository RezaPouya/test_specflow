namespace SpecFlow.Domain.Service;

public interface IPricingService
{
    decimal GetBasketTotalAmount(Basket basket);
}

public class PricingService : IPricingService
{
    public decimal GetBasketTotalAmount(Basket basket)
    {
        if (basket is null)
            return 0;

        if (!basket.Products.Any())
            return 0;

        decimal basketValue = basket.Products.Sum(p => p.Price);
 
       if (basket.User.IsLoggedIn == false)
            return basketValue;

        return basketValue - (basketValue * 0.05m);
    }
}