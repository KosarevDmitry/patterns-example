namespace Patterns.Behavioral.State.Banking;

internal class RedState : State

{
    private decimal _serviceFee;

    public RedState(State state)
    {
        balance = state.Balance;
        account = state.Account;
        Initialize();
    }

    private void Initialize()
    {
        interest    = 0.0m;
        lowerLimit  = -100.0m;
        upperLimit  = 0.0m;
        _serviceFee = 5.00m;
    }

    public override void Deposit(decimal amount)
    {
        balance += amount;
        StateChangeCheck();
    }

    public override void Withdraw(decimal amount)
    {
        balance -= amount + _serviceFee;
        
    }

    public override void PayInterest()
    {
    }

    private void StateChangeCheck()
    {
        if (balance > upperLimit)
        {
            account.State = new SilverState(this);
        }
    }
}