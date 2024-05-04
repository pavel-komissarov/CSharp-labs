using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeMessenger : IAddressee
{
    private readonly IMessenger _messenger;

    public AddresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(BaseMessage baseMessage)
    {
            _messenger.WriteText($"Title: {baseMessage?.Title}\nBody: {baseMessage?.Body}");
    }
}