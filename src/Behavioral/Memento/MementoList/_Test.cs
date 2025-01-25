namespace Patterns.Behavioral.Memento.MementoList;

public class Test
{
    /// <see href= "https://en.wikipedia.org/wiki/Memento_pattern"/>
    [Fact]
    public void MementoList()
    {
        var savedStates = new List<Memento>();
        var originator  = new Memento.Originator();
        originator.Set("State1");
        originator.Set("State2");
        savedStates.Add(originator.SaveToMemento());
        originator.Set("State3");
        savedStates.Add(originator.SaveToMemento());
        originator.Set("State4");
        originator.RestoreFromMemento(savedStates[1]);
        Assert.True(originator.State == "State3");
    }
}