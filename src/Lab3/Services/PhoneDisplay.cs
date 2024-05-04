using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class PhoneDisplay : IPhoneDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public PhoneDisplay(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ShowText(string text)
    {
        _displayDriver.Clear();
        Console.WriteLine(_displayDriver.Draw(text));
    }
}