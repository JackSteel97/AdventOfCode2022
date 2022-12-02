namespace Day2;

public static class Day2
{
    public static int Part1(string[] input)
    {
        var runningTotal = 0;
        foreach (string roundInput in input)
        {
            var round = new Round(roundInput);
            runningTotal += round.Score();
        }

        return runningTotal;
    }
    
    public static int Part2(string[] input)
    {
        var runningTotal = 0;
        foreach (string roundInput in input)
        {
            var round = new RoundPart2(roundInput);
            runningTotal += round.Score();
        }

        return runningTotal;
    }
}