namespace Patterns.Behavioral.Command.Calculator;

internal class User

{
    private Calculator     _calculator = new Calculator();
    private List<ICommand> _commands   = new List<ICommand>();
    private int            _current    = 0;
    public  int            Result => _calculator.Result;

    public void Redo(int levels)
    {
        Console.WriteLine("\n---- Redo {0} levels ", levels);
        // Perform redo operations

        for (int i = 0; i < levels; i++)
        {
            if (_current < _commands.Count - 1)
            {
                ICommand command = _commands[_current++];
                command.Execute();
            }
        }
    }

    public void Undo(int levels)
    {
        for (int i = 0; i < levels; i++)
        {
            if (_current > 0)
            {
                ICommand command = _commands[--_current] as ICommand;
                command.UnExecute();
            }
        }
    }

    public void Compute(char @operator, int operand)
    {
        ICommand command = new CalculatorCommand(
            _calculator, @operator, operand);
        command.Execute();

        // Add command to undo list

        _commands.Add(command);
        _current++;
    }
}