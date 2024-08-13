using System.Collections.Generic;

namespace Patterns.Creational.Protopype.Color;

internal class ColorManager
{
    private Dictionary<string, ColorPrototype> _colors = new();

    public ColorPrototype this[string key]
    {
        get => _colors[key];
        set => _colors.Add(key, value);
    }
}