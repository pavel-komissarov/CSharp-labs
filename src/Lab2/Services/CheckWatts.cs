using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CheckWatts : ICheckWatts
{
    public CheckWattsResult Check(AssemblyPc assemblyPc)
    {
        if (assemblyPc is null)
            throw new ArgumentNullException(nameof(assemblyPc));

        int wattage = 0;

        if (assemblyPc.Ssd != null)
        {
            wattage += assemblyPc.Ssd.Sum(component => component.PowerConsumption);
        }

        if (assemblyPc.Hdd != null)
        {
            wattage += assemblyPc.Hdd.Sum(component => component.PowerConsumption);
        }

        if (assemblyPc.WiFiAdapter != null)
        {
            wattage += assemblyPc.WiFiAdapter.PowerConsumption;
        }

        if (assemblyPc.Gpu != null)
        {
            wattage += assemblyPc.Gpu.PowerConsumption;
        }

        if (assemblyPc.Cpu != null)
        {
            wattage += assemblyPc.Cpu.PowerConsumption;
        }

        if (assemblyPc.Ram != null)
        {
            wattage += assemblyPc.Ram.Sum(component => component.PowerConsumptionWatts);
        }

        if (assemblyPc.PowerSupply is not null && wattage > assemblyPc.PowerSupply.PeakLoad)
        {
            return new CheckWattsResult(false, wattage - assemblyPc.PowerSupply.PeakLoad);
        }

        return new CheckWattsResult(true, 0);
    }
}