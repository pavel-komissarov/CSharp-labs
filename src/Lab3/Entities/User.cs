using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IUser
{
    public User()
    {
        Messages = new List<MessageUser>();
    }

    public ICollection<MessageUser> Messages { get; }

    public void GetMessage(BaseMessage baseMessage)
    {
        Messages.Add(new MessageUser(baseMessage));
    }

    public void CheckMessage(string title)
    {
        Messages.ToList().Find(message => message.Title == title)?.ReadMessage();
    }
}