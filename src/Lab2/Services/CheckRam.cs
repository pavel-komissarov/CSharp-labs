using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CheckRam : ICheckRam
{
    public bool Check(AssemblyPc? assemblyPc)
    {
        bool result = true;

        if (assemblyPc != null
            && assemblyPc.Cpu != null
            && assemblyPc.Ram != null
            && assemblyPc.Motherboard is not null
            && assemblyPc.Motherboard.Chipset != null
            && assemblyPc.Motherboard.Chipset.Xmp != null)
        {
            int frequency = 0;

            foreach (Ram ram in assemblyPc.Ram)
            {
                if (ram.Xmp != null)
                {
                    foreach (Xmp matherboardXmp in assemblyPc.Motherboard.Chipset.Xmp)
                    {
                        foreach (Xmp ramXmp in ram.Xmp)
                        {
                            if (matherboardXmp.Frequency == ramXmp.Frequency)
                            {
                                // If XMP frequency matches, check compatibility with CPU frequency
                                if ((frequency == 0 || frequency <= assemblyPc.Cpu.Frequency)
                                    && frequency < ramXmp.Frequency)
                                {
                                    frequency = ramXmp.Frequency;
                                }
                            }
                            else if (ram.JedecFrequenciesAndVoltages != null)
                            {
                                foreach (JedecFrequencyVoltagePair rJedec in ram.JedecFrequenciesAndVoltages)
                                {
                                    if (assemblyPc.Cpu.Frequency != rJedec.Frequency)
                                    {
                                        // If there is no XMP match, check CPU frequency compatibility among JEDEC
                                        if ((frequency == 0 || frequency <= assemblyPc.Cpu.Frequency)
                                            && frequency < rJedec.Frequency)
                                        {
                                            frequency = rJedec.Frequency;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (ram.JedecFrequenciesAndVoltages != null)
                    {
                        foreach (JedecFrequencyVoltagePair ramJedec in ram.JedecFrequenciesAndVoltages)
                        {
                            if (assemblyPc.Cpu.Frequency != ramJedec.Frequency)
                            {
                                // If there is no XMP, check CPU frequency compatibility among JEDEC
                                if (frequency <= assemblyPc.Cpu.Frequency && frequency < ramJedec.Frequency)
                                {
                                    frequency = ramJedec.Frequency;
                                }
                            }
                        }
                    }
                }

                if (frequency < assemblyPc.Cpu.Frequency)
                {
                    result = false;
                }
            }
        }

        return result;
    }
}