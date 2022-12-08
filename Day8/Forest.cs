namespace Day8;

public class Forest
{
    private readonly Tree[,] _forestGrid;
    private readonly int _edgeLength = 0;
    public Forest(string[] input)
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

    public int GetVisibleTrees()
    {
        var visibleTrees = GetEdgeCount();
        visibleTrees += CountVisibleInnerTrees();
        return visibleTrees;
    }

    private int CountVisibleInnerTrees()
    {
        int total = 0;
        for (int row = 1; row < _edgeLength-1; ++row)
        {
            for (int col = 1; col < _edgeLength-1; ++col)
            {
                if (IsVisible(_forestGrid[row, col]))
                {
                    ++total;
                }
            }
        }

        return total;
    }

    private bool VisibleFromTop(Tree tree)
    {
        for (int row = 0; row < tree.Row; ++row)
        {
            // From top side
            if (_forestGrid[row, tree.Col].Height >= tree.Height)
            {
                // Not visible from this direction
                return false;
            }
        }
        tree.Visible = true;
        return true;
    }

    private bool VisibleFromLeft(Tree tree)
    {
        for (int col = 0; col < tree.Col; ++col)
        {
            // From left side
            if (_forestGrid[tree.Row, col].Height >= tree.Height)
            {
                // Not visible from this direction.
                return false;
            }
        }
        tree.Visible = true;
        return true;
    }

    private bool VisibleFromBottom(Tree tree)
    {
        for(int row = _edgeLength-1; row > tree.Row; --row)
        {
            // From bottom side
            if (_forestGrid[row, tree.Col].Height >= tree.Height)
            {
                // Not visible from this direction.
                return false;
            }
        }
        
        tree.Visible = true;
        return true;
    }

    private bool VisibleFromRight(Tree tree)
    {
        for(int col = _edgeLength-1; col > tree.Col; --col)
        {
            // From right side
            if (_forestGrid[tree.Row, col].Height >= tree.Height)
            {
                // Not visible from this direction.
                return false;
            }
        }
        tree.Visible = true;
        return true;
    }

    private bool IsVisible(Tree tree)
    {
        return VisibleFromLeft(tree) || VisibleFromTop(tree) || VisibleFromRight(tree) || VisibleFromBottom(tree);
    }

    private int GetEdgeCount()
    {
        return ((_edgeLength - 2) * 4) + 4;
    }
}