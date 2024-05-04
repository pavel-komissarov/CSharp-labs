namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IClonable<T>
    where T : BaseComponent
{
    T Clone();
}