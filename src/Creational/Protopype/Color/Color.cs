namespace Patterns.Creational.Protopype.Color;

internal class Color : ColorPrototype, IEquatable<Color>
{
    private readonly int _red;
    private readonly int _green;
    private readonly int _blue;

    // Constructor

    public Color(int red, int green, int blue)
    {
        _red   = red;
        _green = green;
        _blue  = blue;
    }


    public override ColorPrototype Clone()
    {
        return this.MemberwiseClone() as ColorPrototype;
    }


    public bool Equals(Color? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (ReferenceEquals(null, other)) return false;
        return _blue == other._blue && _green == other._green && _red == other._red;
    }
}