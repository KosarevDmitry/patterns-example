namespace Patterns.Structural.AdapterPattern;

public class Test
{
    [Fact]
    public void Structural_Adapter()
    {
        var turkey = new WildTurkey();
        var adapter = new TurkeyAdapter(turkey);
        Tester(adapter);

        void Tester(IDuck duck)
        {
            duck.Fly();
            duck.Quack();
        }
    }
}