using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem()
    {
        Mode = "local";
    }

    public string Mode { get; init; }

    public void Move(string source, string destination)
    {
        if (File.Exists(source))
        {
            File.Move(source, destination);
        }
        else
        {
            throw new FileNotFoundException($"Source file {source} not found");
        }
    }

    public void Copy(string source, string destination)
    {
        if (File.Exists(source))
        {
            File.Copy(source, destination);
        }
        else
        {
            throw new FileNotFoundException($"Source file {source} not found");
        }
    }

    public void Delete(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            throw new FileNotFoundException($"File {path} not found");
        }
    }

    public void Rename(string path, string newName)
    {
        if (File.Exists(path))
        {
            string newFilePath =
                Path.Combine(
                    Path.GetDirectoryName(path) ?? throw new InvalidOperationException(),
                    newName);
            File.Move(path, newFilePath);
        }
        else
        {
            throw new FileNotFoundException($"File {path} not found");
        }
    }

    public string TreeList(IWriterTree writerTree, string path, int depth = 1)
    {
        if (Directory.Exists(path))
        {
            var directoryInfo = new DirectoryInfo(path);
            writerTree?.BuildTree(directoryInfo, depth);
            return writerTree?.OutPut() ?? string.Empty;
        }

        throw new DirectoryNotFoundException($"Directory {path} not found");
    }

    public string ShowFile(string path)
    {
        if (File.Exists(path))
        {
            return new Models.File(Path.GetFileName(path), path).Show();
        }

        throw new FileNotFoundException($"File {path} not found");
    }

    public IFileSystem? Clone()
    {
        return new LocalFileSystem();
    }
}