using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : BaseComponent, IClonable<Hdd>
{
    public Hdd(int capacity, int spindleSpeed, int powerConsumption, string name)
    {
        Capacity = capacity > 0 ? capacity : throw new ArgumentException("Capacity must be positive");
        SpindleSpeed = spindleSpeed > 0 ? spindleSpeed : throw new ArgumentException("Spindle speed must be positive");
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new ArgumentException("Power consumption must be positive");
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int Capacity { get; set; }
    public int SpindleSpeed { get; set; }
    public int PowerConsumption { get; set; }
    public override string Name { get; set; }

    public Hdd Clone()
    {
        return new Hdd(Capacity, SpindleSpeed, PowerConsumption, Name);
    }
}