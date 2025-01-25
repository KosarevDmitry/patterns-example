namespace Patterns.Behavioral.Observer.Observer1;

public class _Test
{
    [Fact]
    public void Observer()
    {
        var publisher = new Publisher();
        var observer = new Observer();
       using (var unsSubscribe= publisher.Subscribe(observer))
       {
           Assert.Single(publisher.Observers);
           publisher.SendMessage("Abba");
           Assert.Single(observer.Messages);
       }
        Assert.Empty(publisher.Observers);
        var publisher1  = new Publisher();
        using (var unsSubscribe1= observer.Register(publisher1))
        {
            Assert.Single(publisher1.Observers);
            publisher1.SendMessage("Boney M");
            Assert.Equal(2, observer.Messages.Count);
        }
        Assert.Empty(publisher1.Observers);

    }
}