namespace Patterns.Other;

public class FileStream : Stream
{
 

    private readonly FileStreamStrategy _strategy;

      
    ~FileStream()
    {
        // Preserved for compatibility since FileStream has defined a
        // finalizer in past releases and derived classes may depend
        // on Dispose(false) call.
        Dispose(false);
    }

              
    public FileStream()
    {
      
        _strategy = new FileStreamStrategy();
    }

    // _strategy can be null only when ctor has thrown
    protected override void Dispose(bool disposing) {
        //_strategy?.DisposeInternal(disposing);
    }

    public override async ValueTask DisposeAsync()
    {
        //  await _strategy.DisposeAsync().ConfigureAwait(false);

        // For compatibility, derived classes must only call base.DisposeAsync(),
        // otherwise we would end up calling Dispose twice (one from base.DisposeAsync() and one from here).
        if (!_strategy.IsDerived)
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }
    }

      
      
}