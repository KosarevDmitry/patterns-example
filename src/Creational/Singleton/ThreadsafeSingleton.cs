namespace Patterns.Creational.Singleton;

public sealed class Singleton
{
    private static          Singleton instance = null;
    private static readonly object    padlock  = new object();

    Singleton()
    {
    }

    public static Singleton Instance
    {
        get

        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }
    }
}