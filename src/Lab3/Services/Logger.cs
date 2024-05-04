using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Logger : ILogger
{
    private readonly string _path;

    public Logger(string path)
    {
        _path = path;
    }

    public void Write(string message)
    {
        File.WriteAllText(_path, $"Log:\n message was sanded\n Message: {message}");
    }
}