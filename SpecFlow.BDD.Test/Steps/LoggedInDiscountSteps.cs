using FluentAssertions;
using SpecFlow.Domain.Service;
using TechTalk.SpecFlow;

namespace SpecFlow.BDD.Test.Steps;

[Binding]
public class LoggedInDiscountSteps
{
    private User _user;
    private Basket _basket;
    private List<Product> _products;
    private readonly IPricingService _pricingService = new PricingService();

    [Given(@"a user that is not logged in")]
    public void GivenAUserThatIsNotLoggedIn()
    {
        _user = new User(false);
    }

    [Given(@"a user that is logged in")]
    public void GivenAUserThatIsLoggedIn()
    {
        _user = new User( true);
    }

    [Given(@"an empty basket")]
    public void GivenAnEmptyBasket()
    {
        _basket = new Basket()
        {
            User = _user
        };
    }

    [When(@"a (.*) that costs (.*) \$ is added to basket")]
    public void WhenAnItemThatCostsIsAddedToBasket(string itemName, decimal price)
    {
        _basket.Products.Add(new Product()
        {
            Name = itemName,
            Price = price
        });
    }

    [Then(@"the basket value is (.*)\$")]
    public void ThenThenBasketValueIs(decimal expectedBasketValue)
    {
        var basketValue = _pricingService.GetBasketTotalAmount(_basket);
        basketValue.Should().Be(expectedBasketValue);
    }
}