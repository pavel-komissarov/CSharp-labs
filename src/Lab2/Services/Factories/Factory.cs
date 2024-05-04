using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public abstract class Factory<T>
    where T : BaseComponent, IClonable<T>
{
    public T CreateByName(string? name, ICollection<T> repositoryComponents)
    {
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        return repositoryComponents.ToList().Find(repository => repository.Name == name)?.Clone() ??
               throw new ComponentNotFoundByNameException("Can't find component with this name: " + name);
    }
}