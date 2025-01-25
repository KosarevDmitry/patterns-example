namespace Patterns.Creational.Factory.CharConverter;

public class _Test
{
    [Fact]
    public void Factory_CharConverter()
    {
        Factory1 f1 = new();
        Factory2 f2 = new();
        Model    m1 = f1.Make('a');
        Model    m2 = f2.Make('a');
        Assert.NotEqual(m2.Code, m1.Code);
    }
}