namespace Day6;

public static class Day6
{
    public static int Part1(string input)
    {
        for (int i = 0; i < input.Length-4; ++i)
        {
            var possibleMarker = input[i..(i + 4)];
            if (AllUnique(possibleMarker))
            {
                return i + 4;
            }
        }

        throw new InvalidDataException("No marker found");
    }
    
    public static int Part2(string input)
    {
        for (int i = 0; i < input.Length-14; ++i)
        {
            var possibleMarker = input[i..(i + 14)];
            if (AllUnique(possibleMarker))
            {
                return i + 14;
            }
        }

        throw new InvalidDataException("No marker found");
    }

    private static bool AllUnique(string input)
    {
        return input.AsEnumerable().Distinct().Count() == input.Length;
    }
}