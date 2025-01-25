using  Patterns.Behavioral.ChainOfResponsibility.Calculator.Handlers;

namespace Patterns.Behavioral.ChainOfResponsibility.Calculator;

public class Test
{
    [Theory]
    [InlineData(new double[] { 1, 2, 3, 4, 5 })]
    public void ChainOfResponsibility_Calculator(double[] n)
    {
        Addition       addition       = new();
        Subtraction    subtraction    = new();
        Multiplication multiplication = new();
        addition.AddChain(subtraction);
        subtraction.AddChain(multiplication);
        Assert.Equal(n.Sum(),                      addition.Handle(n, Action.Add));
        Assert.Equal(n.Aggregate((x, y) => x - y), addition.Handle(n, Action.Substruct));
        Assert.Equal(n.Aggregate((x, y) => x * y), addition.Handle(n, Action.Multiply));
        Assert.Throws<InvalidOperationException>(() => addition.Handle(n, Action.Divide));
    }
}