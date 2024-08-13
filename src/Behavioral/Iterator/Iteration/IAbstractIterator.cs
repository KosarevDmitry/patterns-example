namespace Patterns.Behavioral.Iterator.Iteration;

internal interface IAbstractIterator

{
    Item First();
    Item Next();
    bool IsDone      { get; }
    Item CurrentItem { get; }
}