namespace Day5;

public static class Day5
{
    public static string Part1(string[] input)
    {
        var stacks = new CrateStacks(input);
        stacks.Execute();

        return stacks.GetResult();
    }
    
    public static string Part2(string[] input)
    {
        var stacks = new CrateStacks(input);
        stacks.Execute9001();

        return stacks.GetResult();
    }
}