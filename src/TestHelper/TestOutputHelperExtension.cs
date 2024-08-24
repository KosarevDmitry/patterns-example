using Xunit.Abstractions;

namespace Patterns.TestHelper;

public static class TestOutputHelperExtension
{
    public static ITestOutputHelper output;

    public static void dump(this object o)
    {
        output.WriteLine($"{o}");
    }
}