namespace PatternTests.BasePattern;

public class Derived : Child
{
    private int _i;

    public Derived(int i) : base(i)
    {
        _i = i;
    }

    public override void Make()
    {
        List.Add("Derived Make " + _i);
    }

    public override void Do()
    {
        List.Add("Derived Do");
        Make();
    }
}