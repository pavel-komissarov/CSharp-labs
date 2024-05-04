using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CpuValidator : IComponentValidator
{
    public void ValidateAssembly(AssemblyPc assemblyPc)
    {
        if (assemblyPc?.Cpu is null)
            throw new NotCompatibleComponentsException("Cpu must be plugged");

        // Check compatibility of motherboard and processor sockets
        if (assemblyPc.Motherboard?.CpuSocket != assemblyPc.Cpu.Socket)
            throw new NotCompatibleComponentsException("Cpu is not compatible with motherboard");

        if (assemblyPc.Motherboard?.Bios is { Supported.Count: > 0 })
        {
            if (assemblyPc.Cpu.Name != null && !assemblyPc.Motherboard.Bios.Supported.Contains(assemblyPc.Cpu.Name))
                throw new NotCompatibleComponentsException("Cpu is not compatible with motherboard");
        }
    }
}