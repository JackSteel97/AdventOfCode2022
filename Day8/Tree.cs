namespace Day8;

public record Tree(int Row, int Col, int Height)
{
    public bool Visible { get; set; } = false;
}