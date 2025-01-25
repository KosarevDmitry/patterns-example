namespace Patterns.Behavioral.Observer.Observer1;

public  class Unsubscriber : IDisposable
{
    private readonly IObserver<Payload>        _observer;
    private readonly IList<IObserver<Payload>> _observers;

    public Unsubscriber(
        IObserver<Payload>        observer,
        IList<IObserver<Payload>> observers)
    {
        _observer  = observer;
        _observers = observers;
    }

    public void Dispose()
    {
        _observers.Remove(_observer);
        GC.SuppressFinalize(this);
    }
}