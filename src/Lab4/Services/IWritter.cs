namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IWritter
{
    public string Mode { get; init; }
    void Write(string message);
}