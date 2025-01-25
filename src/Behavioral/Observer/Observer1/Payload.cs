namespace Patterns.Behavioral.Observer.Observer1;

public class Payload(string message, string publisher)
{
    public string Message { get; init; } = message;
    public string Publisher { get; init; } = publisher;
    public  DateTime Timestamp =>DateTime.Now;
}