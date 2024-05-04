using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IWriterTree
{
    void BuildTree(DirectoryInfo path, int depth);
    string OutPut();
}