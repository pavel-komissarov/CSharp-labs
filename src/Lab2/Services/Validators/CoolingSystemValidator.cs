using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CoolingSystemValidator : IComponentValidator
{
    public void ValidateAssembly(AssemblyPc assemblyPc)
    {
        // Check the compatibility of the cooling system with the processor
        if (assemblyPc?.CoolingSystem != null && assemblyPc?.Cpu?.Socket != null &&
            assemblyPc.CoolingSystem.Sockets is not null &&
            !assemblyPc.CoolingSystem.Sockets.Contains(assemblyPc.Cpu.Socket))
            throw new NotCompatibleComponentsException("Cooling system is not compatible with cpu");
    }
}