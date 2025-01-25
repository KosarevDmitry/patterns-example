namespace Patterns.Behavioral.State.Banking;

public class Test
{
    /// <see href="https://www.dofactory.com"/>
    [Fact]
    public void State_banking()
    {
        Account account = new Account("Jim Johnson");
        Assert.Equal(0, account.Balance);
        account.Deposit(500.0m);
        Assert.Equal(500, account.Balance);
        account.Withdraw(100.0m);
        Assert.Equal(400, account.Balance);
        account.PayInterest();
        Assert.Equal(400, account.Balance);
        account.Deposit(601.0m);
        account.PayInterest();
        Assert.Equal(1051.0500m, account.Balance);
        account.Withdraw(551.05m);
        Assert.Equal(500.0m, account.Balance);
        account.Withdraw(401.00m);
        Assert.Equal(99.0m, account.Balance);
        account.Withdraw(19.00m);
        Assert.Equal(75.0m, account.Balance);
    }
}