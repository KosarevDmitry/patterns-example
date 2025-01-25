namespace Patterns.Structural.Decorator.Bike;

public class Test
{
    [Fact]
    private void Decorator_Bike()
    {
        var basicBike = new AluminiumBike();
        BikeAccessories upgraded = new SportPackage(basicBike);
        upgraded = new SecurityPackage(upgraded);
        Assert.True(100 == basicBike.GetPrice());
        Assert.True(111 == upgraded.GetPrice());
    }
}