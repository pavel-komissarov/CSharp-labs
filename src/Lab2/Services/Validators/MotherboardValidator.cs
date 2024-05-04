using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class MotherboardValidator : IComponentValidator
{
    public void ValidateAssembly(AssemblyPc assemblyPc)
    {
        if (assemblyPc is null)
            throw new ArgumentNullException(nameof(assemblyPc));

        if (assemblyPc.Motherboard is null)
            throw new NotCompatibleComponentsException("Motherboard must be plugged");

        // Check the compatibility of the motherboard's SATA ports with storage devices
        if (assemblyPc is { Ssd: not null, Hdd: not null } && assemblyPc.Motherboard.NumberOfSataPorts <
            assemblyPc.Hdd.Count + assemblyPc.Ssd.Where(ssd => ssd.ConnectionType == "SATA").ToList().Count)
            throw new NotCompatibleComponentsException("SATA lines not enough for storage devices");

        if (assemblyPc.WiFiAdapter is not null)
        {
            if (!assemblyPc.Motherboard.WiFi)
                throw new NotCompatibleComponentsException("Motherboard is not compatible with WiFi adapter");
        }

        // Checking the presence of a WiFi adapter when the option is activated on the motherboard
        if (assemblyPc.WiFiAdapter is null && assemblyPc.Motherboard.WiFi)
            throw new NotCompatibleComponentsException("WiFi adapter must be plugged");

        // Check to see if there are enough PCIE lanes for the SSD
        if (assemblyPc.Ssd != null && assemblyPc.Motherboard.NumberOfPcieLines <
            assemblyPc.Ssd.Where(ssd => ssd.ConnectionType == "PCIE").ToList().Count)
            throw new NotCompatibleComponentsException("PCIE lines not enough for storage devices");

        if (assemblyPc.Hdd is null && assemblyPc.Ssd is null)
            throw new NotCompatibleComponentsException("At least one storage device must be specified");

        // Check the compatibility of the DDR standard of RAM and motherboard
        if (assemblyPc.Motherboard.DdrStandard != assemblyPc.Ram?.First().DdrVersion)
            throw new NotCompatibleComponentsException("Ram is not compatible with motherboard");
    }
}