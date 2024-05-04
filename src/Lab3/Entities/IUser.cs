using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IUser
{
    public void GetMessage(BaseMessage baseMessage);
    public void CheckMessage(string title);
}