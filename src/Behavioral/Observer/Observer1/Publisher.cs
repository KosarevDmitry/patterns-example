namespace Patterns.Behavioral.Observer.Observer1;

public class Publisher : IObservable<Payload>
{
    public  List<IObserver<Payload>> Observers { get; } = [];

    public IDisposable Subscribe(IObserver<Payload> observer)
    {
        if (!Observers.Contains(observer))
        {
            Observers.Add(observer);
        }

        return new Unsubscriber(observer, Observers);
    }

    public void SendMessage(string message)
    {
        foreach (var observer in Observers)
        {
            try
            {
                observer.OnNext(new Payload(message: message, publisher:nameof(Publisher)) );
                observer.OnCompleted();
            }
            catch (Exception e)
            {
                observer.OnError(e);
            }  
        }
    }
}