namespace Day7;

public static class Day7
{
    public static int Part1(string[] input)
    {
        var builder = new FileSystemBuilder(input);
        var root = builder.Build();
        return TotalDirectorySizes(root);
    }

    private static int TotalDirectorySizes(Directory dir)
    {
        var total = 0;
        var currentSize = dir.GetSize();
        if (currentSize <= 100000)
        {
            total += currentSize;
        }

        foreach (var child in dir.GetChildren())
        {
            if (child is Directory childDir)
            {
                total += TotalDirectorySizes(childDir);
            }
        }

        return total;
    }

    public static int Part2(string[] input)
    {
        int totalSpace = 70000000;
        int updateSpace = 30000000;
        
        var builder = new FileSystemBuilder(input);
        var root = builder.Build();

        int usedSpace = root.GetSize();
        int unusedSpace = totalSpace - usedSpace;
        int requiredSpaceToFree = updateSpace - unusedSpace;
        var result = FindSmallestDirectoryBiggerThan(root, requiredSpaceToFree);
        return result;
    }

    private static int FindSmallestDirectoryBiggerThan(Directory dir, int size)
    {
        var smallestDirSize = dir.GetSize();

        foreach (var child in dir.GetChildren())
        {
            if (child is Directory childDir)
            {
                var childSize = FindSmallestDirectoryBiggerThan(childDir, size);
                if (childSize < smallestDirSize && childSize >= size)
                {
                    smallestDirSize = childSize;
                }
            }
        }

        return smallestDirSize;
    }
}