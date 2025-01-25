namespace Patterns.Behavioral.State.Banking;

internal class GoldState : State
{
    public GoldState(State state) : this(state.Balance, state.Account)
    {
    }

    public GoldState(decimal balance, Account account)
    {
        this.balance = balance;
        this.account = account;
        Initialize();
    }

    private void Initialize()
    {
        interest   = 0.05m;
        lowerLimit = 1000.0m;
        upperLimit = 10000000.0m;
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
        if (balance < 0.0m)
        {
            account.State = new RedState(this);
        }
        else if (balance < lowerLimit)
        {
            account.State = new SilverState(this);
        }
    }
}