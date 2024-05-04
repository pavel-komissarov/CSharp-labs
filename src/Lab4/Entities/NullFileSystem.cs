using Itmo.ObjectOrientedProgramming.Lab4.Services.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class NullFileSystem : IFileSystem
{
    public NullFileSystem()
    {
        Mode = "null";
    }

    public string Mode { get; init; }

    public void Move(string source, string destination)
    {
        throw new FileSystemWasntSetException();
    }

    public void Copy(string source, string destination)
    {
        throw new FileSystemWasntSetException();
    }

    public void Delete(string path)
    {
        throw new FileSystemWasntSetException();
    }

    public void Rename(string path, string newName)
    {
        throw new FileSystemWasntSetException();
    }

    public string TreeList(IWriterTree writerTree, string path, int depth = 1)
    {
        throw new FileSystemWasntSetException();
    }

    public string ShowFile(string path)
    {
        throw new FileSystemWasntSetException();
    }

    public IFileSystem? Clone()
    {
        return new NullFileSystem();
    }
}