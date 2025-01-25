namespace Patterns.Creational.Abstract.War;

public class _Test
{
    [Fact]
    public void Abstract_War()
    {
        War bigw   = new War(new BigCountry());
        War smallw = new War(new SmallCountry());
        var r1     = bigw.GetResult();
        var r2     = smallw.GetResult();
        Assert.True(bigw.GetResult() > smallw.GetResult());
    }
}