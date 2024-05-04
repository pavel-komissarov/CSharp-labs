using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class RamValidator : IComponentValidator
{
    public void ValidateAssembly(AssemblyPc assemblyPc)
    {
        if (assemblyPc?.Ram is null)
            throw new NotCompatibleComponentsException("Ram must be plugged");

        // Check the compatibility of the amount RAM with the motherboard
        if (assemblyPc.Motherboard?.NumberOfRamSlots < assemblyPc.Ram.Count)
            throw new NotCompatibleComponentsException("Ram is not compatible with motherboard");

        // Check for compatibility of DDR versions of RAM and motherboard
        if (assemblyPc.Ram.Any(ram => ram.DdrVersion != assemblyPc.Ram.First().DdrVersion))
            throw new NotCompatibleComponentsException("Ram is not compatible with motherboard");

        // Check the compatibility of the DDR standard of RAM and motherboard
        if (assemblyPc.Motherboard?.DdrStandard != assemblyPc.Ram.First().DdrVersion)
            throw new NotCompatibleComponentsException("Ram is not compatible with motherboard");
    }
}