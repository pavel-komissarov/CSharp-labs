using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class GpuValidator : IComponentValidator
{
    public void ValidateAssembly(AssemblyPc assemblyPc)
    {
        if (assemblyPc is null) throw new ArgumentNullException(nameof(assemblyPc));

        if (assemblyPc.Gpu != null && assemblyPc.PcCase?.MaxVideoCardHeight < assemblyPc.Gpu.Height
                                   && assemblyPc.PcCase.MaxVideoCardWidth < assemblyPc.Gpu.Lenght)
            throw new NotCompatibleComponentsException("Gpu is not compatible with pc case");

        if (assemblyPc.Motherboard?.Bios is { Supported.Count: > 0 })
        {
            if (assemblyPc.Cpu?.Name != null && !assemblyPc.Motherboard.Bios.Supported.Contains(assemblyPc.Cpu.Name))
                throw new NotCompatibleComponentsException("Cpu is not compatible with motherboard");
        }

        // Checking the presence of a video card or integrated video core if there is no video card
        if (assemblyPc.Cpu != null && assemblyPc.Gpu is null && assemblyPc.Cpu.VideoCore)
            throw new NotCompatibleComponentsException("Gpu must be plugged");

        // Check the compatibility of the video card with the motherboard
        if (assemblyPc.Ssd != null && assemblyPc.Motherboard?.NumberOfPcieLines <
            assemblyPc.Ssd.Where(ssd => ssd.ConnectionType == "PCIE").ToList().Count + 1)
            throw new NotCompatibleComponentsException("Gpu is not compatible with motherboard");
    }
}