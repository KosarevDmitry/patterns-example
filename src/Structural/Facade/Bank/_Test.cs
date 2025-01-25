namespace Patterns.Structural.Facade.Bank;

public class _Test
{
    
    [Fact]
    private void Facade_Bank()
    {
        Mortgage mortgage = new Mortgage();
        Customer customer = new Customer("Ann McKinsey");
        bool eligible = mortgage.IsEligible(customer, 125000);
    }
}