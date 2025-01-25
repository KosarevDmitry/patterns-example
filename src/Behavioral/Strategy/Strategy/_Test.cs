namespace Patterns.Behavioral.Strategy.Strategy;

public class _Test
{
    [Fact]
    public void Strategy()
    {
        SortedList studentRecords = new SortedList();
        studentRecords.Add("Samual");
        studentRecords.Add("Jimmy");
        studentRecords.Add("Sandra");

        studentRecords.SetSortStrategy(new QuickSort());
        studentRecords.Sort();
        studentRecords.SetSortStrategy(new ShellSort());
        studentRecords.Sort();
        studentRecords.SetSortStrategy(new MergeSort());
        studentRecords.Sort();
    }
}