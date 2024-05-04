using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class DisplayDriver : IDisplayDriver
{
    private Color _color;

    public DisplayDriver()
    {
        _color = Color.White;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public string Draw(string text)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text);
    }
}