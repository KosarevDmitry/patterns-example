namespace Patterns.BasePattern;

public class Child
{
    private int _i;
    public List<string> List = new();

    public Child(int i)
    {
        _i = i;
        Do();
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
}