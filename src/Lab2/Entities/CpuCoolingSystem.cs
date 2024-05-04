using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCoolingSystem : BaseComponent, IClonable<CpuCoolingSystem>
{
    public CpuCoolingSystem(int dimensions, ICollection<string>? sockets, int tdp, string name)
    {
        Dimensions = dimensions > 0
            ? dimensions
            : throw new ArgumentException("Argument must be positive", nameof(dimensions));
        Sockets = sockets ?? throw new ArgumentNullException(nameof(sockets));
        Tdp = tdp > 0
            ? tdp
            : throw new ArgumentException("Argument must be positive", nameof(tdp));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int Dimensions { get; set; }
    public ICollection<string>? Sockets { get; }
    public int Tdp { get; set; }
    public override string Name { get; set; }

    public CpuCoolingSystem Clone()
    {
        return new CpuCoolingSystem(Dimensions, Sockets, Tdp, Name);
    }
}