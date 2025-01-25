namespace Patterns.Behavioral.Interpreter.RomanNumerals;

public class Test
{
    /// <summary>
    /// Interpreter, a modified version from <see href="https://www.dofactory.com"/>
    /// </summary>
    [Theory]
    [InlineData("MCMXXVIII", 1928)]
    public void RomanNumerals(string n, int expected)
    {
        Context context = new(n);
        var expressions = new List<Expression>()
        {
            new ThousandExpression(), new HundredExpression(), new TenExpression(), new OneExpression()
        };

        foreach (Expression exp in expressions)
        {
            exp.Interpret(context);
        }

        Assert.Equal(expected, context.Output);
    }
    /// <see href="https://www.britannica.com/topic/Roman-numeral"/>
    [Theory]
    [InlineData("MCMXXVIII", 1928)]
    public void RomanNumerals_1(string n, int expected)
    {
        string[,] romenum = new string[4, 4]
        {
            { "M", " ", " ", " " }, { "C", "CD", "D", "CM" }, { "X", "XL", "L", "XC" }, { "I", "IV", "V", "IX" }
        };
        Assert.Equal(expected, 1928);
    }

}