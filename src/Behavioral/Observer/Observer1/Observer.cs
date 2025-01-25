namespace Patterns.Behavioral.Observer.Observer1;

public class Observer : IObserver<Payload>
{
    public  List<Payload> Messages { get;}= [];

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(Payload payload)
    {
        Messages.Add(payload);
    }

    //tricks is the subscription  will stop automatically when the current instance of Observer is disposed
    public IDisposable Register(Publisher publisher)
    {
        return publisher.Subscribe(this);
    }
}