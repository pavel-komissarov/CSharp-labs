using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class WriterTree : IWriterTree
{
    public WriterTree(string fileIcon, string directoryIcon)
    {
        FileIcon = fileIcon;
        DirectoryIcon = directoryIcon;
    }

    public string? Tree { get; private set; }
    public string FileIcon { get; init; }
    public string DirectoryIcon { get; init; }

    public void BuildTree(DirectoryInfo path, int depth)
    {
        Tree = new TreeBuilder().BuilderDirectory(path, depth).Output(FileIcon, DirectoryIcon);
    }

    public string OutPut()
    {
        return Tree ?? string.Empty;
    }
}