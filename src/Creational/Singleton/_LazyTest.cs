using Patterns.Creational.Singleton.Lazy;
namespace Patterns.Creational.Singleton;

public class _Test
{
    [Fact]
    public void Singleton_LazyInstance()
    {
        var a  = LazyInstance.GetInstance();
        var b  = LazyInstance.GetInstance();
        var c1 = a.Count;
        var c2 = b.Count;
        Assert.Same(a, b);
        Assert.Equal(c1 + 1, c2);
    }
}