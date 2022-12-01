namespace Day1;

public static class Day1
{
    public static int Part1(string[] input)
    {
        int currentMax = 0;
        int elfRunningTotal = 0;
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                // Start a new Elf.
                currentMax = Math.Max(currentMax, elfRunningTotal);
                elfRunningTotal = 0;
            }
            else
            {
                elfRunningTotal += Convert.ToInt32(line);
            }
        }
        currentMax = Math.Max(currentMax, elfRunningTotal);
        return currentMax;
    }
    
    public static int Part2(string[] input)
    {
        int elfRunningTotal = 0;
        int[] top3Maxs = new[] { 0, 0, 0 };
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                // Start a new Elf.
                TrackTopCarriers(top3Maxs, elfRunningTotal);
                elfRunningTotal = 0;
            }
            else
            {
                elfRunningTotal += Convert.ToInt32(line);
            }
        }
        TrackTopCarriers(top3Maxs, elfRunningTotal);
        return top3Maxs.Sum();
    }

    private static void TrackTopCarriers(int[] top3Maxs, int elfRunningTotal)
    {
        
        for (int i = 0; i < top3Maxs.Length; ++i)
        {
            if (elfRunningTotal > top3Maxs[i])
            {
                top3Maxs[i] = elfRunningTotal;
                Array.Sort(top3Maxs);
                break;
            }
        }
    }
}