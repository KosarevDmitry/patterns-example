namespace Patterns.Creational.Prototype.Figure;

public class _Test
{
    
    [Fact]
    public void Prototype_Figure()
    {
        IFigure figure       = new Rectangle(30, 40);
        IFigure clonedFigure = (IFigure)figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();

        figure       = new Circle(30);
        clonedFigure = (IFigure)figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();
    }

}