namespace Day7;

public class Directory : IFileSystemItem
{
    private readonly string _name;
    private readonly IFileSystemItem? _parent;
    private readonly List<IFileSystemItem> _children;

    public Directory(string name, IFileSystemItem? parent)
    {
        _name = name;
        _parent = parent;
        _children = new List<IFileSystemItem>();
    }

    public List<IFileSystemItem> GetChildren()
    {
        return _children;
    }

    public void AddChild(IFileSystemItem item)
    {
        _children.Add(item);
    }
    
    public IFileSystemItem FindChildByName(string name)
    {
        var found =  _children.Find(x => x.GetName() == name);
        if (found == null) throw new InvalidDataException("This shouldn't happen from the puzzle input");
        return found;
    }
    
    /// <inheritdoc />
    public IFileSystemItem? GetParent()
    {
        return _parent;
    }

    /// <inheritdoc />
    public int GetSize()
    {
        return _children.Sum(x => x.GetSize());
    }

    /// <inheritdoc />
    public string GetName()
    {
        return _name;
    }
}