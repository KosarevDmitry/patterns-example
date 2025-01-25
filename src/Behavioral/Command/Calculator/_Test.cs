namespace Patterns.Behavioral.Command.Calculator;

public class Test
{
    /// <summary>
    /// A little bit modified version Command from <see href="https://www.dofactory.com/net/command-design-pattern">docfactory</see> 
    /// </summary>
    [Fact]
    public void Command_Calculator()
    {
        var user = new User();
        user.Compute('+', 100);
        Assert.True(user.Result == 100);
        user.Compute('-', 50);
        Assert.True(user.Result == 50);
        user.Compute('*', 10);
        Assert.True(user.Result == 500);
        user.Compute('/', 2);
        Assert.True(user.Result == 250);

        // Undo 4 commands
        user.Undo(4);
        Assert.True(user.Result == 0);

        // Redo 3 commands
        user.Redo(3);
        Assert.True(user.Result == 500);
    }

}