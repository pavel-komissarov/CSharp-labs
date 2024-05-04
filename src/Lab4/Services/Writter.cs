using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class Writter : IWritter
{
    public Writter()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Mode = "console";
    }

    public string Mode { get; init; }

    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}