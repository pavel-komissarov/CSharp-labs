namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class CheckWattsResult
{
    public CheckWattsResult(bool result, int diff)
    {
        Result = result;
        Diff = diff;
    }

    public bool Result { get; set; }
    public int Diff { get; set; }
}