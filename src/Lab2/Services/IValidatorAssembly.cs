using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IValidatorAssembly
{
    AssemblyPc Valid(AssemblyPc assemblyPc);
}