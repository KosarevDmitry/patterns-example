namespace PatternTests.BasePattern;

public class Child
{
    private int _i;
    public List<string> List = new();

    public Child(int i)
    {
        _i = i;
        Do();
    }

    public Child()
    {
        Do1();
        Make1(2);
    }

    public virtual void Make()
    {
        List.Add("Child Make " + _i);
    }

    public virtual void Do()
    {
        Make();
        List.Add("Child Do");
    }


    public virtual void Make1(int i)
    {
        List.Add("Child Make " + i);
    }

    public virtual void Do1()
    {
        List.Add("Child Do");
    }
}