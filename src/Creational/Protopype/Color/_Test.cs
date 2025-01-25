namespace Patterns.Creational.Protopype.Color;

public class _Test
{
    [Fact]
    public void Prototype_Color()
    {
        var colormanager = new ColorManager();
        var red          = new Color(255, 0, 0);
        colormanager["red"] = red;
        Color redclone = colormanager["red"].Clone() as Color;

        Assert.NotEqual(red.GetHashCode(), redclone.GetHashCode());
        Assert.Equal(red, redclone);
    }
}