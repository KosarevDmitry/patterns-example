namespace Patterns.Behavioral.Memento.Care;

public class _Test
{
    [Fact]
    public void Memento_Care()
    {
        Originator o = new Originator();
        o.State = "On";
        Caretaker c = new Caretaker();
        c.Memento = o.CreateMemento();
        o.State   = "Off";
        o.SetMemento(c.Memento);
    }
}