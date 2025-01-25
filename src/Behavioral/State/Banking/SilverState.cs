namespace Patterns.Behavioral.State.Banking;

internal class SilverState : State
{
    public SilverState(State state) : this(state.Balance, state.Account)
    {
    }

    public SilverState(decimal balance, Account account)
    {
        this.balance = balance;
        this.account = account;
        Initialize();
    }

    private void Initialize()
    {
        interest   = 0.0m;
        lowerLimit = 100.0m;
        upperLimit = 1000.0m;
    }

    public override void Deposit(decimal amount)
    {
        balance += amount;
        StateChangeCheck();
    }

    public override void Withdraw(decimal amount)
    {
        balance -= amount;
        StateChangeCheck();
    }

    public override void PayInterest()
    {
        balance += interest * balance;
        StateChangeCheck();
    }

    private void StateChangeCheck()
    {
        if (balance < lowerLimit)
        {
            account.State = new RedState(this);
        }
        else if (balance > upperLimit)
        {
            account.State = new GoldState(this);
        }
    }
}