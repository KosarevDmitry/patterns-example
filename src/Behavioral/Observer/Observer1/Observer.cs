namespace Patterns.Behavioral.Observer.Observer1;

public class Observer : IObserver<Payload>
{
    public string Message { get; set; }

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(Payload value)
    {
        Message = value.Message;
    }

    //tricks is the subscription  will stop automatically when the current instance of Observer is disposed
    public IDisposable Register(Subject subject)
    {
        return subject.Subscribe(this);
    }
}