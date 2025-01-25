namespace Patterns.Creational.Multiton;

public class Test
{
    [Fact]
    void MultiTon()
    {
        var m0 = Multiton.GetInstance(MultitonType.Zero);
        var m1 = Multiton.GetInstance(MultitonType.One);
        var m2 = Multiton.GetInstance(MultitonType.Two);
        Assert.Equal(MultitonType.Zero.ToString(), m0.ToString());
        Assert.Equal(MultitonType.One.ToString(),  m1.ToString());
        Assert.Equal(MultitonType.Two.ToString(),  m2.ToString());
    }
}