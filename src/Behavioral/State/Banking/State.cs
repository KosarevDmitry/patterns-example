namespace Patterns.Behavioral.State.Banking;

internal abstract class State
{
    protected Account account;
    protected decimal  balance;

    protected decimal interest;
    protected decimal lowerLimit;
    protected decimal upperLimit;

    // Properties

    public Account Account
    {
        get { return account; }
        set { account = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public abstract void Deposit(decimal  amount);
    public abstract void Withdraw(decimal amount);
    public abstract void PayInterest();
}