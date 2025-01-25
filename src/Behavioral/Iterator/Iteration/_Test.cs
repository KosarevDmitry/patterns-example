using Xunit.Abstractions;

namespace Patterns.Behavioral.Iterator.Iteration;

public class Test
{ 
    
    [Fact]
    public void Iteration()
    {
        DemoCollection collection = new();
        Enumerable.Range(0, 9).ToList().ForEach(x =>
            collection[x] = new Item($"item {x}")
        );

        DemoIterator iterator = collection.CreateIterator();
        iterator.Step = 2;
        int count = 0;
        for (Item item = iterator.First(); !iterator.IsDone; item = iterator.Next())
        {
            
            Assert.Equal($"item {count}", item.Name);
            count += 2;
        }
    }
}