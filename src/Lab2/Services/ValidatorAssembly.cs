using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ValidatorAssembly : IValidatorAssembly
{
    private readonly ICollection<IComponentValidator> _validators;

    public ValidatorAssembly(ICollection<IComponentValidator> validators)
    {
        _validators = validators;
    }

    public AssemblyPc Valid(AssemblyPc assemblyPc)
    {
        if (assemblyPc == null) throw new ArgumentNullException(nameof(assemblyPc));

        foreach (IComponentValidator validator in _validators)
        {
            validator.ValidateAssembly(assemblyPc);
        }

        return assemblyPc;
    }
}