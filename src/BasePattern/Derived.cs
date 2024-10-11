namespace Patterns.BasePattern;

public class Derived : Child
{
    private int _i;

    public Derived(int i) : base(i)
    {
        _i = i;
    }

    public override void Make()
    {
        List.Add("Par Make " + _i);
    }

    public override void Do()
    {
        List.Add("Par Do");
        Make();
    }
}