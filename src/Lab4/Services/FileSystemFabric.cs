using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FileSystemFabric : IFileSystemsFabrics
{
    private readonly Collection<IFileSystem> _fileSystems;

    public FileSystemFabric(Collection<IFileSystem> fileSystems)
    {
        _fileSystems = fileSystems ?? throw new ArgumentNullException(nameof(fileSystems));
    }

    public IFileSystem? CreateFileSystem(string mode)
    {
        return _fileSystems.FirstOrDefault(fileSystem => fileSystem.Mode == mode) == null
            ? throw new FileSystemWasntSetException()
            : _fileSystems.FirstOrDefault(fileSystem => fileSystem.Mode == mode)?.Clone();
    }
}