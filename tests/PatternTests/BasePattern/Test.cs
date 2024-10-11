namespace PatternTests.BasePattern;

public class Test
{
    [Fact]
    public void Do()
    {
        var derived = new Derived(3);
        var ar = derived.List.ToArray();
        Assert.True("Derived Do" == ar[0]);
        Assert.True("Derived Make 0" == ar[1]);
    }
}