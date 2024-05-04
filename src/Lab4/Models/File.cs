namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class File
{
    public File(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; private set; }
    public string Path { get; private set; }

    public string Show()
    {
        if (System.IO.File.Exists(Path))
        {
            return System.IO.File.ReadAllText(Path);
        }

        return $"File not found at path: {Path}";
    }
}