using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Chipset
{
    public Chipset(double frequency, ICollection<Xmp>? xmp)
    {
        Frequency = frequency > 0
            ? frequency
            : throw new ArgumentException("Argument must be positive", nameof(frequency));
        Xmp = xmp;
    }

    public double Frequency { get; set; }
    public ICollection<Xmp>? Xmp { get; }
}