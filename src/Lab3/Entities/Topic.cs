using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic : BaseTopic
{
    private IAddressee _addressee;

    public Topic(string name, IAddressee addressee)
    : base(name)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    public override void SendMessage(BaseMessage baseMessage)
    {
        _addressee.ReceiveMessage(baseMessage ?? throw new ArgumentNullException(nameof(baseMessage)));
    }
}