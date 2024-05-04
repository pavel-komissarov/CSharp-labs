using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class Context
{
    public Context(IWritter writer, IWriterTree writerTree)
    {
        Writer = writer;
        Address = string.Empty;
        FileSystem = new NullFileSystem();
        WriterTree = writerTree;
    }

    public IFileSystem FileSystem { get; private set; }
    public string Address { get; private set; }
    public IWritter Writer { get; private set; }
    public IWriterTree WriterTree { get; private set; }

    public void SetFileSystem(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void TreeGoto(string path)
    {
        Address = path;
    }
}