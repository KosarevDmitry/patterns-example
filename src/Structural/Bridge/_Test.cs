namespace Patterns.Structural.Bridge;

public class _Test
{
    [Fact]
    public void Structural_Bridge()
    {
        var courier = new Сourier();
        var editor = new Editor();
        var actor1 = new Actor(courier);
        actor1.Work();
        actor1.Rest();
        ;
        var actor2 = new Actor(editor);
        actor2.Work();
        actor2.Rest();
        ;
    }
}