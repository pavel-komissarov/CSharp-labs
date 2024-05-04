using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeUser
    : IAddressee
{
    private readonly IUser _user;

    public AddresseeUser(IUser user)
    {
        _user = user;
    }

    public void ReceiveMessage(BaseMessage baseMessage)
    {
        _user.GetMessage(baseMessage);
    }
}