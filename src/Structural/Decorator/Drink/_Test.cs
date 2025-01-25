namespace Patterns.Structural.Decorator.Drink;

public class Test
{
    [Fact]
    private void Decorator_Drink()
    {
        Beverage beverage = new Espresso();
        Beverage beverage2 = new DarkRoast();
        beverage2 = new MochaCondiment(beverage2);
        beverage2 = new MochaCondiment(beverage2);
        beverage2 = new WhipCondiment(beverage2);
        Beverage beverage3 = new HouseBlend();
        beverage3 = new MochaCondiment(beverage3);
        beverage3 = new WhipCondiment(beverage3);
    }
}