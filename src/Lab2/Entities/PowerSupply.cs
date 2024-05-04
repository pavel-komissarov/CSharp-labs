using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply : BaseComponent, IClonable<PowerSupply>
{
    public PowerSupply(int peakLoad, string name)
    {
        PeakLoad = peakLoad > 0 ? peakLoad : throw new ArgumentException("Argument must be positive", nameof(peakLoad));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int PeakLoad { get; set; }
    public override string Name { get; set; }

    public PowerSupply Clone()
    {
        return new PowerSupply(PeakLoad, Name);
    }
}