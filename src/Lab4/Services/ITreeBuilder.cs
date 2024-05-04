using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface ITreeBuilder
{
    IWriterTree BuildTree(string path, int depth);
}