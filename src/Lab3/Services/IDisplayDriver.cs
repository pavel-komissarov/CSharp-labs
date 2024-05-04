using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface IDisplayDriver
{
    public void Clear();
    public string Draw(string text);
    public void SetColor(Color color);
}