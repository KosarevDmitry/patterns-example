using System.Diagnostics;

/// <summary>
/// the test automatically call GetAwaiter,  then  call IsCompleted.  If IsCompleted  returns true
/// then  GetResult  otherwise OnCompleted. 
/// </summary>
public class Async_Await_Pattern
{
    [Fact]
    static async void If_complete_true()
    {
        int actual = await new A(true);
        Assert.Equal(1, actual);
        
        actual = await new A(false);
        Assert.Equal(2, actual);
        
        actual = await new B(true);
        Assert.Equal(1, actual);
        
        actual = await new B(false);
        Assert.Equal(2, actual);
    }


    //similar a ConfiguredTaskAwaitable class
    class A
    {
        private bool _iscompleted;

        public A(bool isCompleted)
        {
            _iscompleted = isCompleted;
        }

        internal B GetAwaiter() => new B(_iscompleted);
    }
}

class B : System.Runtime.CompilerServices.INotifyCompletion
{
    private int a = 1;
    private bool _isCompleted;

    public B(bool isCompleted)
    {
        _isCompleted = isCompleted;
    }

    internal B GetAwaiter() => this;

    public void OnCompleted(Action x)
    {
        Debugger.Break();
        a = 2;
        x.Invoke();
    }

    public int GetResult()
    {
        Debugger.Break();
        return a;
    }

    public bool IsCompleted
    {
        get
        {
            Debugger.Break();
            return _isCompleted;
        }
    }
}

