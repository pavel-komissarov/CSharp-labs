using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IFileSystemsFabrics
{
    IFileSystem? CreateFileSystem(string mode);
}