namespace Patterns.Behavioral.Visitor.Employees;

public class _Test
{
    [Fact]
    public void Visitor_Employees()
    {
        Employees e = new();
        e.Add(new Clerk());
        e.Add(new Director());
        e.Recalculate(new IncomeApprover());
        e.Recalculate(new VacationApprover());
    }
}