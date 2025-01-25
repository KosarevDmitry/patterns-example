namespace Patterns.Behavioral.State.Banking;

internal class Account
{
    private State  _state;
    private string _owner;

    public Account(string owner)
    {
        _owner = owner;
        _state = new SilverState(0.0m, this);
    }

    public decimal Balance => _state.Balance;

    public State State
    {
        get { return _state; }
        set { _state = value; }
    }

    public void Deposit(decimal amount)
    {
        _state.Deposit(amount);
        Console.WriteLine("Deposited {0:C} --- ", amount);
        Console.WriteLine(" Balance = {0:C}",     this.Balance);
        Console.WriteLine(" Status = {0}",        this.State.GetType().Name);
    }

    public void Withdraw(decimal amount)
    {
        _state.Withdraw(amount);
        Console.WriteLine("Withdrew {0:C} --- ", amount);
        Console.WriteLine(" Balance = {0:C}",    this.Balance);
        Console.WriteLine(" Status = {0}\n",     this.State.GetType().Name);
    }

    public void PayInterest()
    {
        _state.PayInterest();
        Console.WriteLine("Interest Paid --- ");
        Console.WriteLine(" Balance = {0:C}", this.Balance);
        Console.WriteLine(" Status = {0}\n",  this.State.GetType().Name);
    }
}