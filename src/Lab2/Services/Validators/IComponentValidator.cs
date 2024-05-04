using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public interface IComponentValidator
{
    void ValidateAssembly(AssemblyPc assemblyPc);
}