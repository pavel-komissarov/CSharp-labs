using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IAddressee
{
    public void ReceiveMessage(BaseMessage baseMessage);
}