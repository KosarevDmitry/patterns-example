namespace Patterns.Behavioral.Observer.Observer2;

public class _Test
{
    [Fact]
    public void Observer2()
    {
        ConcreteSubject s = new ConcreteSubject();

        s.Attach(new ConcreteObserver(s, "X"));
        s.Attach(new ConcreteObserver(s, "Y"));
        s.Attach(new ConcreteObserver(s, "Z"));

        s.SubjectState = "ABC";
        s.Notify();
    }
    
}