namespace Patterns.Behavioral.Visitor.ExpressionPrinting;

public class Test
{
    [Fact]
    public void Visitor_ExpressionPrinting()
    {
        var e = new Addition(
            new Addition(
                new Literal(1),
                new Literal(2)
            ),
            new Literal(3)
        );

        var printingVisitor = new ExpressionPrinting();
        e.Accept(printingVisitor);
    }
}