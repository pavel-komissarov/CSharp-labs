using System;
using System.IO;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Models.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Models.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class TreeBuilder
{
    public Directory BuilderDirectory(DirectoryInfo directoryInfo, int depth)
    {
        if (directoryInfo == null) throw new ArgumentNullException(nameof(directoryInfo));
        if (depth < 0) throw new ArgumentOutOfRangeException(nameof(depth));

        var directory = new Directory(directoryInfo.Name, directoryInfo.FullName);

        if (depth <= 0) return directory;

        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            directory.AddFile(new File(fileInfo.Name, fileInfo.FullName));
        }

        foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
        {
            directory.AddDirectory(BuilderDirectory(subDirectoryInfo, depth - 1));
        }

        return directory;
    }
}