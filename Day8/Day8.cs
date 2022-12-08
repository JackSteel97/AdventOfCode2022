namespace Day8;

public static class Day8
{
    public static int Part1(string[] input)
    {
        var forest = new Forest(input);
        return forest.GetVisibleTrees();
    }

    public static int Part2(string[] input)
    {
        var forest = new ForestPart2(input);
        return forest.GetHighestScenicScore();
    }
}