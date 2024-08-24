using Patterns.TestHelper;
using Xunit.Abstractions;

namespace Patterns.OtherPatterns.DelegateAbstraction;

public class Tests
{
    public Tests(ITestOutputHelper output) => TestOutputHelperExtension.output = output;

    [Fact]
    public void Run()
    {
       
      var actual=  HandlerSetting.ExchangeRecoveryExceptionCondition.Invoke(new Foo(), new Exception("bar"));
      Assert.True(actual);
    }

    class  Foo: IFoo
    {
        public int Id { get; set; }
    }
}


static class  HandlerSetting
{
  private static readonly DelegateTemplate template;

    static HandlerSetting()
    {
        template = new DelegateTemplate();
        template.ExchangeRecoveryExceptionCondition = (foo, e) =>
        {
           
            Console.WriteLine(foo.Id + " " + e.Message);
            return true;
        };
    }

    public static Func<IFoo, Exception, bool> ExchangeRecoveryExceptionCondition =>
        template.ExchangeRecoveryExceptionCondition;

  
}