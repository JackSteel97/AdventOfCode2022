namespace Day8;

public class ForestPart2
{
    private readonly Tree[,] _forestGrid;
    private readonly int _edgeLength = 0;
    public ForestPart2(string[] input)
    {
        _edgeLength = input.Length;
        _forestGrid = new Tree[input.Length, input.Length];
        for (int row = 0; row < input.Length; ++row)
        {
            for (int col = 0; col < input.Length; ++col)
            {
                _forestGrid[row, col] = new Tree(row, col, (int)char.GetNumericValue(input[row][col])) ;
            }
        }
    }

    public int GetHighestScenicScore()
    {
        int currentBestScore = 0;
        for (int row = 1; row < _edgeLength-1; ++row)
        {
            for (int col = 1; col < _edgeLength-1; ++col)
            {
                var scenicScore = GetScenicScore(_forestGrid[row, col]);
                if (scenicScore > currentBestScore)
                {
                    currentBestScore = scenicScore;
                }
            }
        }

        return currentBestScore;
    }

    private int VisibleDistanceToTop(Tree tree)
    {
        int visibleCount = 0;
        for (int row = tree.Row-1; row >= 0; --row)
        {
            ++visibleCount;
            if (_forestGrid[row, tree.Col].Height >= tree.Height)
            {
                return visibleCount;
            }
        }

        return visibleCount;
    }

    private int VisibleDistanceToLeft(Tree tree)
    {
        int visibleCount = 0;
        for (int col = tree.Col-1; col >= 0; --col)
        {
            ++visibleCount;
            if (_forestGrid[tree.Row, col].Height >= tree.Height)
            {
                return visibleCount;
            }
        }
        return visibleCount;
    }

    private int VisibleDistanceToBottom(Tree tree)
    {
        int visibleCount = 0;
        for(int row = tree.Row+1; row < _edgeLength; ++row)
        {
            ++visibleCount;
            if (_forestGrid[row, tree.Col].Height >= tree.Height)
            {
                return visibleCount;
            }
        }

        return visibleCount;
    }

    private int VisibleDistanceToRight(Tree tree)
    {
        int visibleCount = 0;
        for(int col = tree.Col+1; col < _edgeLength; ++col)
        {
            ++visibleCount;
            if (_forestGrid[tree.Row, col].Height >= tree.Height)
            {
                return visibleCount;
            }
        }
        return visibleCount;
    }

    private int GetScenicScore(Tree tree)
    {
        return VisibleDistanceToBottom(tree) * VisibleDistanceToTop(tree) * VisibleDistanceToLeft(tree) * VisibleDistanceToRight(tree);
    }
}