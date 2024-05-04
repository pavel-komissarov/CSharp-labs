using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Bios
{
    public Bios(string type, string version, ICollection<string> supported)
    {
        Type = type is null ? throw new ArgumentNullException(nameof(type)) : type;
        Version = version is null ? throw new ArgumentNullException(nameof(version)) : version;
        Supported = supported is null ? throw new ArgumentNullException(nameof(supported)) : supported;
    }

    public string Type { get; set; }
    public string Version { get; set; }
    public ICollection<string> Supported { get; }
}