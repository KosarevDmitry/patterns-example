namespace Patterns.Other;

class SyncStream : Stream, IDisposable
{
    private readonly Stream _stream;

    internal SyncStream(Stream stream) => _stream = stream;
			
			
    public override void Close()
    {
        lock (_stream)
        {
            // On the off chance that some wrapped stream has different
            // semantics for Close vs. Dispose, let's preserve that.
            try
            {
                _stream.Close();
            }
            finally
            {
                base.Dispose(true);
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        lock (_stream)
        {
            try
            {
                // Explicitly pick up a potentially methodimpl'ed Dispose
                if (disposing)
                {
                    ((IDisposable)_stream).Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
    }

    public override ValueTask DisposeAsync()
    {
        lock (_stream)
        {
            return _stream.DisposeAsync();
        }
    }
}