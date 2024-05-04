using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class Directory
{
    public Directory(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public ICollection<File>? Files { get; private set; }
    public ICollection<Directory>? Directories { get; private set; }
    public string Name { get; private set; }
    public string Path { get; private set; }

    public void AddFile(File file)
    {
        Files ??= new List<File>();
        Files.Add(file);
    }

    public void AddDirectory(Directory directory)
    {
        Directories ??= new List<Directory>();
        Directories.Add(directory);
    }

    public void RemoveFile(File file)
    {
        Files?.Remove(file);
    }

    public void RemoveDirectory(Directory directory)
    {
        Directories?.Remove(directory);
    }

    public void PrintName(IWritter writter)
    {
        writter?.Write(Name);
    }

    public string Output(string fileIcon = "📄", string directoryIcon = "📁", int depth = 0)
    {
        var result = new StringBuilder();
        string indent = new string('\t', depth);

        result.Append(string.Format(CultureInfo.InvariantCulture, "{0}{2}: {1}\n", indent, Name, directoryIcon));

        if (Files != null)
        {
            result.Append(string.Join(
                string.Empty,
                Files.Select(file =>
                    string.Format(CultureInfo.InvariantCulture, "{0}\t{2}: {1}\n", indent, file.Name, fileIcon))));
        }

        if (Directories == null) return result.ToString();

        result.Append(string.Join(
            string.Empty,
            Directories.Select(directory => directory.Output(fileIcon, directoryIcon, depth + 1))));

        return result.ToString();
    }
}