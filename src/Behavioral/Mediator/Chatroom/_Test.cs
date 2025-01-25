namespace Patterns.Behavioral.Mediator.Chatroom;

public class Test
{
    ///<see href="https://www.dofactory.com"/>
    [Fact]
    private void Mediator_Chat()
    {
        var chatroom = new Chatroom();
        var George   = new Beatle("George");
        var Paul     = new Beatle("Paul");
        var Ringo    = new Beatle("Ringo");
        var John     = new Beatle("John");
        var Yoko     = new NonBeatle("Yoko");

        chatroom.Register(George);
        chatroom.Register(Paul);
        chatroom.Register(Ringo);
        chatroom.Register(John);
        chatroom.Register(Yoko);

        Yoko.Send("John", "Hi John!");
        Paul.Send("Ringo", "All you need is love");
        Ringo.Send("George", "My sweet Lord");
        Paul.Send("John", "Can't buy me love");
        John.Send("Yoko", "My sweet love");

        Assert.True(Yoko.Outbox.Count == 1 && John.Outbox.Count == 1 && Paul.Outbox.Count == 2 &&
                    Ringo.Outbox.Count == 1 && George.Outbox.Count == 0);
        Assert.True(Yoko.Inbox.Count == 1 && John.Inbox.Count == 2 && Paul.Inbox.Count == 0 && Ringo.Inbox.Count == 1 &&
                    George.Inbox.Count == 1);
    }

}