namespace Patterns.Other;

public abstract class Stream :  IDisposable, IAsyncDisposable {

    public void Dispose() => Close();

        public virtual void Close()
        {
            
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }
		
	public virtual ValueTask DisposeAsync()
        {
            try
            {
                Dispose();
                return default;
            }
            catch (Exception exc)
            {
                return ValueTask.FromException(exc);
            }
        }
}

class FileStreamStrategy{
	 public bool IsDerived =false;
	}