using Patterns.Creational.Factory.CharConverter;

namespace Patterns.OtherPatterns;

public class FilterTest
{
    [Theory]
    [InlineData(4)]
    public void Run(int expected)
    {
        Filter filter = new Filter();
        var    f      = filter.Configure(a => { a.UseMiddleware(); });
        var    f1     = filter.Configure(f);
        var    f2     = filter.Configure(f1);
        var    a      = new A();
        f2(a);

        Assert.Equal(expected, a.count);
    }
}

public interface IA
{
    public void UseMiddleware();
}

public class A : IA
{
    public int count = 0;

    public void UseMiddleware()
    {
        count++;
    }
}

interface IFilter
{
    public Action<IA> Configure(Action<IA> next);
}

public class Filter : IFilter
{
    public Action<IA> Configure(Action<IA> next)
    {
        return a =>
        {
            a.UseMiddleware();
            next(a);
        };
    }
}