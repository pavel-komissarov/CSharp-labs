using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : BaseComponent, IClonable<Ram>
{
    public Ram(
        int capacity,
        ICollection<JedecFrequencyVoltagePair>? jedecFrequenciesAndVoltages,
        ICollection<Xmp>? xmp,
        string? formFactor,
        int ddrVersion,
        int powerConsumptionWatts,
        string name)
    {
        Capacity = capacity > 0
            ? capacity
            : throw new ArgumentException("Argument must be positive", nameof(capacity));
        JedecFrequenciesAndVoltages = jedecFrequenciesAndVoltages ??
                                      throw new ArgumentNullException(nameof(jedecFrequenciesAndVoltages));
        Xmp = xmp;
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        DdrVersion = ddrVersion > 0
            ? ddrVersion
            : throw new ArgumentException("Argument must be positive", nameof(ddrVersion));
        PowerConsumptionWatts = powerConsumptionWatts > 0
            ? powerConsumptionWatts
            : throw new ArgumentException("Argument must be positive", nameof(powerConsumptionWatts));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int Capacity { get; set; }
    public ICollection<JedecFrequencyVoltagePair>? JedecFrequenciesAndVoltages { get; }
    public ICollection<Xmp>? Xmp { get; }
    public string? FormFactor { get; set; }
    public int DdrVersion { get; set; }
    public int PowerConsumptionWatts { get; set; }
    public override string Name { get; set; }

    public Ram Clone()
    {
        return new Ram(
            Capacity,
            JedecFrequenciesAndVoltages,
            Xmp,
            FormFactor,
            DdrVersion,
            PowerConsumptionWatts,
            Name);
    }
}