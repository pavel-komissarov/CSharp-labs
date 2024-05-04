using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Telegram : ITelegram
{
    public void PostMessage(string text)
    {
        Console.WriteLine($"Telegram:\n{text}");
    }
}