namespace Day4;

public static class Day4
{
    public static int Part1(string[] input)
    {
        var total = 0;
        foreach (var line in input)
        {
            var sections = GetSections(line);
            if (IsFullyContained(sections[0], sections[1]) || IsFullyContained(sections[1], sections[0]))
            {
                total++;
            }
        }

        return total;
    }

    private static List<CleaningSection> GetSections(string input)
    {
        var result = new List<CleaningSection>(4);
        var elfParts = input.Split(",");
        foreach (var elfPart in elfParts)
        {
            var sections = elfPart.Split("-");
            result.Add(new CleaningSection(Convert.ToInt32(sections[0]), Convert.ToInt32(sections[1])));
        }

        return result;
    }

    private static bool IsFullyContained(CleaningSection container, CleaningSection other)
    {
        return other.start >= container.start && other.end <= container.end;
    }

    private static bool IsOverlapping(CleaningSection container, CleaningSection other)
    {
        return (other.start >= container.start && other.start <= container.end) || (other.end >= container.start && other.end <= container.end);
    }

    public static int Part2(string[] input)
    {
        var total = 0;
        foreach (var line in input)
        {
            var sections = GetSections(line);
            if (IsOverlapping(sections[0], sections[1]) || IsOverlapping(sections[1], sections[0]))
            {
                total++;
            }
        }

        return total;
    }
}