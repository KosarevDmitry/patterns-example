namespace PatternTests.BasePattern;

public class Test
{
     
    [Fact]
    public void Loop()
    {
        var a = new Derived(3).List.ToArray();
        
        Assert.True("Derived Do" == a[0]);
        Assert.True("Derived Make 0" == a[1]);
        Assert.True("Child Make 3" == a[2]);
        Assert.True("Derived Make 0" == a[3]);
        Assert.True("Child Make 3" == a[4]);
        Assert.True("Child Do" == a[5]);
        
        // real example
        //D:\src\aspnetcore\src\Mvc\test\Mvc.FunctionalTests\Infrastructure\MvcTestFixture.cs
        var b = new Derived().List.ToArray();
        Assert.True("Derived Do" == b[0]);
        Assert.True("Child Do" == b[1]);
        Assert.True("Derived Make 2" == b[2]);
        Assert.True("Child Make 2" == b[3]);
    }
}