namespace Patterns.OtherPatterns.DelegateAbstraction;

public interface  IFoo
{
 int Id { get; set; }
}

/// <summary>
/// Using  Delegate instead function
/// </summary>
/// <para>
/// <example>
/// <a href= "https://github.com/rabbitmq/rabbitmq-dotnet-client/blob/a9cdaeebf33dcb9064616e3e4c36f3b5565afcc9/projects/RabbitMQ.Client/client/api/TopologyRecoveryExceptionHandler.cs#L8">
/// https://github.com/rabbitmq/rabbitmq-dotnet-client/blob/a9cdaeebf33dcb9064616e3e4c36f3b5565afcc9/projects/RabbitMQ.Client/client/api/TopologyRecoveryExceptionHandler.cs#L8
/// </a>
///</example>
/// </para>
public class DelegateTemplate
{
    private static readonly Func<IFoo, Exception, bool> s_defaultExchangeExceptionCondition = (e, ex) => true;
    
    private Func<IFoo, Exception, bool> _exchangeRecoveryExceptionCondition;
      
    public Func<IFoo, Exception, bool> ExchangeRecoveryExceptionCondition
    {
        get => _exchangeRecoveryExceptionCondition ?? s_defaultExchangeExceptionCondition;

        set
        {
            if (_exchangeRecoveryExceptionCondition != null)
                throw new InvalidOperationException($"Cannot modify {nameof(ExchangeRecoveryExceptionCondition)} after it has been initialized.");

            _exchangeRecoveryExceptionCondition = value ?? throw new ArgumentNullException(nameof(ExchangeRecoveryExceptionCondition));
        }
    }
    
}


