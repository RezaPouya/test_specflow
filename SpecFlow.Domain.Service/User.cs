namespace SpecFlow.Domain.Service;

public class User
{
    public User(bool isLoggedIn)
    {
        IsLoggedIn = isLoggedIn;
    }
    public bool IsLoggedIn { get; set; }
}