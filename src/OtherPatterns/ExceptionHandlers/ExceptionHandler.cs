namespace Patterns.OtherPatterns;

class BarrierPostPhaseException : Exception
{
    public BarrierPostPhaseException(Exception ex)
    {
    }
}

public class Catch
{

    [Fact]
    void TransformExceptionType()
    {
        Assert.Throws<BarrierPostPhaseException>(() => Failed());
    }

    /// <summary>
    ///  Throw in finally block
    /// </summary>
    /// <exception cref="BarrierPostPhaseException"></exception>
    void Failed()
    {
        Exception _exception = null;
        try
        {
            int[] ar = { 1,2 }; 
            var r        = ar[2]; // error
            _exception = null; // reset the exception if it was set previously
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
        finally
        {
            if (_exception != null)
                throw new BarrierPostPhaseException(_exception);
        }
    }


    [Fact]
    void CheckInnerException()
    {
        Task task = Task.Run(() => { throw null; });
        try
        {
            task.Wait();
        }
        catch (AggregateException aex)
        {
            if (aex.InnerException is NullReferenceException)
                Console.WriteLine("Null!");
            else
                throw;
        }
    }
}