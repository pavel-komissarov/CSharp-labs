using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class MessageUser : BaseMessage
{
    public MessageUser(BaseMessage massage)
        : base(massage?.Title, massage?.Body, massage?.SeverityLevel)
    {
        Read = false;
    }

    public bool Read { get; private set; }

    public void ReadMessage()
    {
        Read = Read ? throw new MessageCantBeReadException("Cant read because message already read!") : true;
    }
}