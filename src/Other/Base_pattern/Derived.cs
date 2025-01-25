namespace PatternTests.BasePattern;

public class Derived : Child
{
    private int _i;

    public Derived(int i) : base(i)
    {
        _i = i;
    }

    public Derived() : base()
    {
    }


    public override void Make()
    {
        List.Add("Derived Make " + _i);
        base.Make();
    }

    public override void Do()
    {
        List.Add("Derived Do");
        Make();
        base.Do();
    }


    public override void Make1(int i)
    {
        List.Add("Derived Make " + i);
        base.Make1(i);
    }

    public override void Do1()
    {
        List.Add("Derived Do");
        base.Do1();
    }
}