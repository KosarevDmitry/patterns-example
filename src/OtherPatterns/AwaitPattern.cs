using System.Diagnostics;

/// <summary>
/// Automatically call GetAwaiter  then IsCompleted.  if IsCompleted is true
/// then  GetResult
/// otherwise OnCompleted 
/// </summary>
public class AwaitTests
{
    [Fact]
    static async void If_complete_true()
    {
int actual = await new A();
        Assert.Equal(2, actual);
    }

    //similar a ConfiguredTaskAwaitable class
    class A
    {
        internal Boo GetAwaiter()
        {
            return new Boo();
        }
    }

    class Boo : System.Runtime.CompilerServices.INotifyCompletion
    {
        private int a = default;

        public void OnCompleted(Action x)
        {
            
            x.Invoke();
        }

        public int GetResult() => a + 1;


        public bool IsCompleted
        {
            get
            {
                a = 1;
                return true;
            }
        }
    }

    [Fact]
    static async void If_complete_false()
    {
        var actual = await new B();
        Assert.Equal(7, actual);
    }

    class B : System.Runtime.CompilerServices.INotifyCompletion
    {
        private int a = default;

        internal B GetAwaiter() => this;

        public void OnCompleted(Action x)
        {
            Debugger.Break();
            x.Invoke();
        }

        public int GetResult() => a + 1;


        public bool IsCompleted {
            get
            {
                Debugger.Break();
                return false;
            }
        } //call OnCompleted  with action `void MoveNext()`
    }
}


