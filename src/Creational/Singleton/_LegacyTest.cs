using Patterns.Creational.Singleton.Balancer;

namespace Patterns.Creational.Singleton;

public class _LegacyTest
{
    
    [Fact]
    public void Singleton_LoadBalancer()
    {
        var b = Legacy.GetLoadBalancer();
    }
    [Fact]
    public void Singleton_Legacy()
    {
        var a  = Legacy.GetLoadBalancer();
        var b  = Legacy.GetLoadBalancer();
        var c1 = a.Count;
        var c2 = a.Count;
        var c3 = b.Count;
        Assert.Equal(c1 + 2, c3);
        Assert.Same(a, b);
    }
}