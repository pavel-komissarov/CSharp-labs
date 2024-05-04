using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : BaseComponent, IClonable<WiFiAdapter>
{
    public WiFiAdapter(
        int wiFiStandardVersion,
        bool hasBluetooth,
        int pcieVersion,
        int powerConsumption,
        string name)
    {
        WiFiStandardVersion = wiFiStandardVersion > 0
            ? wiFiStandardVersion
            : throw new ArgumentException("Argument must be positive", nameof(wiFiStandardVersion));
        HasBluetooth = hasBluetooth;
        PcieVersion = pcieVersion > 0
            ? pcieVersion
            : throw new ArgumentException("Argument must be positive", nameof(pcieVersion));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new ArgumentException("Argument must be positive", nameof(powerConsumption));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int WiFiStandardVersion { get; set; }
    public bool HasBluetooth { get; set; }
    public int PcieVersion { get; set; }
    public int PowerConsumption { get; set; }
    public override string Name { get; set; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(WiFiStandardVersion, HasBluetooth, PcieVersion, PowerConsumption, Name);
    }
}