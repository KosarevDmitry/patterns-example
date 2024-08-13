namespace Patterns.Behavioral.ChainOfResponsibility.Calculator.Handlers;

public class Addition : BaseHandler
{
    public override double? Handle(double[] values, Action action)
    {
        if (action == Action.Add)
        {
            double result = 0.0;
            foreach (var value in values)
            {
                result += value;
            }

            return result;
        }

        return Next?.Handle(values, action) ?? throw new InvalidOperationException("Next  is not initialized");
    }
}