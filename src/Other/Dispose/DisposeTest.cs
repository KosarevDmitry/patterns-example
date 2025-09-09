namespace Patterns.Other;


public class DisposeTest
{
    [Fact]
    public void Test()
    {
        FileStream fs = new FileStream();
        BufferedStream bs = new BufferedStream(fs);
        bs.Dispose();

    }
}