using System.Collections;
using Xunit.Abstractions;

namespace testme.CollectionTests;

public class IEnumerableTests
{
    private ITestOutputHelper _output;
    public IEnumerableTests(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public void ManualLoop()
    {
        using IEnumerator<int> e = Fib().GetEnumerator();
        while (e.MoveNext())
        {
            int i = e.Current;
            if (i > 10) break;
           _output.WriteLine($"{i} ");
        }
    }

    [Fact]
    public void AutomaticLoop()
    {
        foreach (int i in Fib())
        {
            if (i > 10) break;
            _output.WriteLine($"{i} ");
        }
    }

    public static IEnumerable<int> Fib()
    {
        int prev = 0, next = 1;
        yield return prev;
        yield return next;
        while (true)
        {
            int sum = prev + next;
            yield return sum;
            prev = next;
            next = sum;
        }
    }

    [Fact]
    public void CompilerGeneratedManual()
    {
        using IEnumerator<int> e = _Fib().GetEnumerator();
        while (e.MoveNext())
        {
            int i = e.Current;
            if (i > 10) break;
            _output.WriteLine($"{i} "); //0 1 1 2 3 5 8 
        }
    }

// CompilerGenerated
    public static IEnumerable<int> _Fib() => new Fib(-2);
}

// real state machine created by compiler 
//the names was changed  for readability
//[CompilerGenerated]
internal sealed class Fib : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
{
    private int state;
    private int current;
    private int initialThreadId;
    private int prev;
    private int next;
    private int sum;
    int IEnumerator<int>.Current => current;
    object IEnumerator.Current => current;

    public Fib(int state)
    {
        this.state = state;
        initialThreadId = Environment.CurrentManagedThreadId;
    }

    public bool MoveNext()
    {
        switch (state)
        {
            default:
                return false;
            case 0:
                state = -1;
                prev = 0;
                next = 1;
                current = prev;
                state = 1;
                return true;
            case 1:
                state = -1;
                current = next;
                state = 2;
                return true;
            case 2:
                state = -1;
                break;
            case 3:
                state = -1;
                prev = next;
                next = sum;
                break;
        }

        sum = prev + next;
        current = sum;
        state = 3;
        return true;
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        if (state == -2 &&
            initialThreadId == Environment.CurrentManagedThreadId)
        {
            state = 0;
            return this;
        }

        return new Fib(0);
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<int>)this).GetEnumerator();
    void IEnumerator.Reset() => throw new NotSupportedException();

    void IDisposable.Dispose()
    {
    }
}