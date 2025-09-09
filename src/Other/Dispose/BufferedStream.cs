namespace Patterns.Other;

public sealed class BufferedStream : Stream
{
        
    private Stream? _stream;                                   
    private byte[]? _buffer;
  
    public BufferedStream(Stream stream)
    {
      _stream = stream;
       

    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && _stream != null)
            {
                try
                {
                    // Flush();
                }
                finally
                {
                    _stream.Dispose();
                }
            }
        }
        finally
        {
            _stream = null;
            _buffer = null;
          
                
            base.Dispose(disposing);
        }
    }

    public override async ValueTask DisposeAsync()
    {
        try
        {
            if (_stream != null)
            {
                try
                {
                    //  await FlushAsync().ConfigureAwait(false);
                }
                finally
                {
                    await _stream.DisposeAsync().ConfigureAwait(false);
                }
            }
        }
        finally
        {
            _stream = null;
            _buffer = null;
               
        }
    }
}