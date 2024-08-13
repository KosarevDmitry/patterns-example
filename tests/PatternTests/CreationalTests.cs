using Patterns.Creational.Factory.Resume;
using Patterns.Creational.Factory.CharConverter;
using Patterns.Creational.Abstract.War;
using Patterns.Creational.Prototype.Figure;
using Patterns.Creational.Singleton;
using Patterns.Creational.Singleton.Balancer;
using Patterns.Creational.Singleton.Lazy;
using Patterns.Creational.Multiton;
using Patterns.Creational.Protopype.Color;

namespace PatternTests.Patterns.Creational;

public class CreationalTests
{
    [Fact]
    public void Factory_Resume()
    {
        var documents = new Document[] { new Resume(), new Report() };
        foreach (Document document in documents)
        {
            foreach (Page page in document.Pages)
            {
            }
        }
    }

    [Fact]
    public void Factory_CharConverter()
    {
        Factory1 f1 = new();
        Factory2 f2 = new();
        Model    m1 = f1.Make('a');
        Model    m2 = f2.Make('a');
        Assert.NotEqual(m2.Code, m1.Code);
    }

    [Fact]
    public void Abstract_War()
    {
        War bigw   = new War(new BigCountry());
        War smallw = new War(new SmallCountry());
        var r1     = bigw.GetResult();
        var r2     = smallw.GetResult();
        Assert.True(bigw.GetResult() > smallw.GetResult());
    }

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

    [Fact]
    public void Prototype_Color()
    {
        var colormanager = new ColorManager();
        var red          = new Color(255, 0, 0);
        colormanager["red"] = red;
        Color redclone = colormanager["red"].Clone() as Color;

        Assert.NotEqual(red.GetHashCode(), redclone.GetHashCode());
        Assert.Equal(red, redclone);
    }

    [Fact]
    public void Singleton_LazyInstance()
    {
        var a  = LazyInstance.GetInstance();
        var b  = LazyInstance.GetInstance();
        var c1 = a.Count;
        var c2 = b.Count;
        Assert.Same(a, b);
        Assert.Equal(c1 + 1, c2);
    }

    [Fact]
    public void Singleton_LoadBalancer()
    {
        var b = Legacy.GetLoadBalancer();
    }


    [Fact]
    public void Singleton_Legacy()
    {
        var a  = Legacy.GetLoadBalancer();
        var b  = Legacy.GetLoadBalancer();
        var c1 = a.Count;
        var c2 = a.Count;
        var c3 = b.Count;
        Assert.Equal(c1 + 2, c3);
        Assert.Same(a, b);
    }

    [Fact]
    void MultiTon()
    {
        var m0 = Multiton.GetInstance(MultitonType.Zero);
        var m1 = Multiton.GetInstance(MultitonType.One);
        var m2 = Multiton.GetInstance(MultitonType.Two);
        Assert.Equal(MultitonType.Zero.ToString(), m0.ToString());
        Assert.Equal(MultitonType.One.ToString(),  m1.ToString());
        Assert.Equal(MultitonType.Two.ToString(),  m2.ToString());
    }
}