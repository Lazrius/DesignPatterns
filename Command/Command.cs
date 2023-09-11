namespace DesignPatterns.Command;

public class Invoker
{
    private Command? _command = null;
    
    public void SetCommand(Command command)
    {
        _command = command;
    }

    /// <summary>
    /// Execute a command
    /// </summary>
    /// <param name="command">If provided, replace the existing command within the invoker prior to execution</param>
    /// <exception cref="InvalidOperationException">A command was not set and not provided as a parameter.</exception>
    public void ExecuteCommand(Command? command = null)
    {
        if (command is not null)
        {
            _command = command;
        }
        else if (_command is null) 
        {
            throw new InvalidOperationException("Cannot execute a command without setting one first.");
        }

        _command.Execute();
    }
}

public abstract class Command
{
    public abstract void Execute();
}