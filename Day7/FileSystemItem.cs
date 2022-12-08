namespace Day7;

public interface IFileSystemItem
{
    IFileSystemItem? GetParent();
    int GetSize();
    string GetName();
}