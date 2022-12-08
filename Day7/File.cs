namespace Day7;

public class File : IFileSystemItem
{
    private readonly int _size;
    private readonly string _name;
    private readonly IFileSystemItem? _parent;

    public File(int size, string name, IFileSystemItem? parent)
    {
        _size = size;
        _name = name;
        _parent = parent;
    }

    /// <inheritdoc />
    public IFileSystemItem? GetParent()
    {
        return _parent;
    }

    /// <inheritdoc />
    public int GetSize()
    {
        return _size;
    }

    /// <inheritdoc />
    public string GetName()
    {
        return _name;
    }
}