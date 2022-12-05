namespace Day5;

public class CrateStacks
{
    private List<Stack<char>> _stacks = new List<Stack<char>>();
    private List<Instruction> _instructions = new List<Instruction>();

    public CrateStacks(string[] input)
    {
        List<string> stacksInput = new List<string>();
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            stacksInput.Add(line);
        }

        List<string> instructions = input.ToList().GetRange(stacksInput.Count + 1, input.Length - stacksInput.Count - 1);

        SetUpStacks(stacksInput);
        SetupInstructions(instructions);
    }

    public void Execute()
    {
        foreach (var instruction in _instructions)
        {
            Execute(instruction);
        }
    }
    
    public void Execute9001()
    {
        foreach (var instruction in _instructions)
        {
            Execute9001(instruction);
        }
    }

    public string GetResult()
    {
        string result = "";
        foreach (var stack in _stacks)
        {
            if (stack.TryPop(out char crate))
            {
                result += crate;
            }
        }

        return result;
    }

    private void Execute(Instruction instruction)
    {
        for (int i = 0; i < instruction.CratesToMove; ++i)
        {
            var movingCrate = _stacks[instruction.SourceIndex].Pop();
            _stacks[instruction.DestinationIndex].Push(movingCrate);
        }
    }
    
    private void Execute9001(Instruction instruction)
    {
        var movingCrates = new List<char>(instruction.CratesToMove);
        for (int i = 0; i < instruction.CratesToMove; ++i)
        {
           movingCrates.Add(_stacks[instruction.SourceIndex].Pop());
        }

        movingCrates.Reverse();
        foreach (var movedCrate in movingCrates)
        {
            _stacks[instruction.DestinationIndex].Push(movedCrate);
        }
    }
    
    private void SetUpStacks(List<string> stacksInput)
    {
        var indexesOfCrateIds = GetIndexesOfCrateIds(stacksInput);
        SetupStacks(indexesOfCrateIds.Count);
        for (int lineIndex = stacksInput.Count-2; lineIndex >= 0; --lineIndex)
        {
            var line = stacksInput[lineIndex];
            for (int stackIndex = 0; stackIndex < indexesOfCrateIds.Count; ++stackIndex)
            {
                var stackIdIndex = indexesOfCrateIds[stackIndex];
                if (!char.IsWhiteSpace(line[stackIdIndex]))
                {
                    _stacks[stackIndex].Push(line[stackIdIndex]);
                }
            }
        }
    }

    private void SetupInstructions(List<string> instructionsInput)
    {
        var instructions = new List<Instruction>();
        foreach (var line in instructionsInput)
        {
            int? num = null;
            int? from = null;
            int? to = null;
            var parts = line.Split(" ");
            foreach (var part in parts)
            {
                if (part.All(char.IsNumber))
                {
                    var value = Convert.ToInt32(part);
                    if (num == null)
                    {
                        num = value;
                    }else if (from == null)
                    {
                        from = value - 1;
                    }else if (to == null)
                    {
                        to = value - 1;
                    }                
                }
            }

            var instruction = new Instruction(num.Value, from.Value, to.Value);
            instructions.Add(instruction);
        }

        _instructions = instructions;
    }

    private void SetupStacks(int howMany)
    {
        for (int i = 0; i < howMany; ++i)
        {
            _stacks.Add(new Stack<char>());
        }
    }

    private List<int> GetIndexesOfCrateIds(List<string> stacksInput)
    {
        List<int> indexesOfCrateIds = new List<int>();
        int currentIndex = 0;
        foreach (var character in stacksInput[stacksInput.Count - 1])
        {
            if (!char.IsWhiteSpace(character))
            {
                indexesOfCrateIds.Add(currentIndex);
            }

            currentIndex++;
        }

        return indexesOfCrateIds;
    }
}