using Patterns.Behavioral.ListOfSignatories.Signatories;

namespace Patterns.Behavioral.ListOfSignatories;

public class Test
{
    [Fact]
    public void ChainOfResponsibility_Signatories()
    {
        var list = new Approvallist();
        Assert.True(list.All(v => v.Value == null));
        Chief chief = new();
        Finance finance = new();
        Marketing marketing = new();
        Sales sales = new();
        Secretary secretary = new();

        chief.AddChain(marketing);
        marketing.AddChain(sales);
        sales.AddChain(finance);
        finance.AddChain(chief);
        secretary.AddChain(chief);

        var result = chief.Handle(new Document() { Idea = "bad", Income = 100.0m }, list);
        Assert.True(result.All(v => v.Value != null));
        var rejected = result.Where(v => v.Value.Approval == false).ToArray();
        Assert.Equal(3, rejected.Length);
        var rejectedDivisions = rejected.Select(x => x.Key).ToArray();
        Assert.Collection(rejectedDivisions,
            div => { Assert.True(div == Division.Finance); },
            div => { Assert.True(div == Division.Sales); },
            div => { Assert.True(div == Division.Chief); }
        );
    }
}