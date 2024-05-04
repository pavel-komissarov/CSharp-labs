using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class JedecFrequencyVoltagePair
{
    public JedecFrequencyVoltagePair(int frequency, int voltageVolts)
    {
        Frequency = frequency > 0 ? frequency : throw new ArgumentException("Argument must be positive", nameof(frequency));
        VoltageVolts = voltageVolts > 0 ? voltageVolts : throw new ArgumentException("Argument must be positive", nameof(voltageVolts));
    }

    public int Frequency { get; set; }
    public int VoltageVolts { get; set; }
}