namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IFileSystem
{
    public string Mode { get; init; }
    void Move(string source, string destination);
    void Copy(string source, string destination);
    void Delete(string path);
    void Rename(string path, string newName);
    public string TreeList(IWriterTree writerTree, string path, int depth = 1);
    string ShowFile(string path);
    IFileSystem? Clone();
}