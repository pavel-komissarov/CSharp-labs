using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Xmp
{
    public Xmp(ICollection<int>? timings, int voltageVolts, int frequencyMHz)
    {
        Timings = timings ?? throw new ArgumentNullException(nameof(timings));
        VoltageVolts = voltageVolts > 0
            ? voltageVolts
            : throw new ArgumentException("Argument must be positive", nameof(voltageVolts));
        Frequency = frequencyMHz > 0
            ? frequencyMHz
            : throw new ArgumentException("Argument must be positive", nameof(frequencyMHz));
    }

    public ICollection<int>? Timings { get; }
    public int VoltageVolts { get; set; }
    public int Frequency { get; set; }
}