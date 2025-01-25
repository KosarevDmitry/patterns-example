namespace Patterns.Structural.Proxy.Math;

public class _Test
{
    
    [Theory]
    [InlineData(1, 2, 4, true)]
    [InlineData(1, 2, 3, false)]
    private void Proxy(int x, int y, int sum, bool expected)
    {
        MathProxy proxy = new MathProxy();
        int r = proxy.Add(x, y);
        Assert.True(expected == (sum == r));
    }
}