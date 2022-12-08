namespace Day7;

public class FileSystemBuilder
{
    private readonly Directory _root;
    private Directory _currentDirectory;
    private readonly string[] _input;

    public FileSystemBuilder(string[] input)
    {
        _input = input;
        _root = new Directory("/", null);
        _currentDirectory = _root;
    }

    public Directory Build()
    {
        for (int i = 0; i < _input.Length; ++i)
        {
            var row = _input[i];
            var command = ParseCommand(row);
            var newIndex = ExecuteCommand(command, i);
            i = newIndex;
        }

        return _root;
    }

    private void ChangeDirectory(string target)
    {
        if (target == "/")
        {
            _currentDirectory = _root;
        }
        else if (target == "..")
        {
            _currentDirectory = (Directory)_currentDirectory.GetParent();
        }
        else
        {
            _currentDirectory = (Directory)_currentDirectory.FindChildByName(target);
        }
    }

    private Command ParseCommand(string input)
    {
        var parts = input.Split(" ");
        var commandName = parts[1];
        var arg = parts.Length > 2 ? parts[2] : null;
        return new Command(commandName, arg);
    }

    private List<string> List(int rowIndex)
    {
        var results = new List<string>();
        for (int i = rowIndex + 1; i < _input.Length; ++i)
        {
            var row = _input[i];
            if (row.StartsWith("$")) return results;
            results.Add(row);
        }

        return results;
    }

    private void ProcessListResults(List<string> results)
    {
        foreach (var result in results)
        {
            if (result.StartsWith("dir"))
            {
                ParseDir(result);
            }
            else
            {
                ParseFile(result);
            }
            
        }
    }

    private void ParseDir(string input)
    {
        var parts = input.Split(" ");
        var dir = new Directory(parts[1], _currentDirectory);
        _currentDirectory.AddChild(dir);
    }

    private void ParseFile(string input)
    {
        var parts = input.Split(" ");
        var file = new File(Convert.ToInt32(parts[0]), parts[1], _currentDirectory);
        _currentDirectory.AddChild(file);
    }

    private int ExecuteCommand(Command command, int rowIndex)
    {
        int newRowIndex = rowIndex;
        if (command.CommandName == "cd")
        {
            ChangeDirectory(command.Arg);
        }else if (command.CommandName == "ls")
        {
            var listResults = List(rowIndex);
            ProcessListResults(listResults);
            newRowIndex += listResults.Count;
        }

        return newRowIndex;
    }
}