namespace Patterns.Behavioral.Visitor.Painting;

public class Test
{
    [Fact]
    public void Visitor_Painting()
    {
        Picture picture = new Picture(new Scetch1(), new Scetch2());
        Assert.Equal(40, picture.Price);
    }
}