using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class CorporateMessageDistributionSystem
{
    private ICollection<BaseTopic> _topics;

    public CorporateMessageDistributionSystem(ICollection<BaseTopic>? topics)
    {
        _topics = topics ?? new List<BaseTopic>();
    }

    public void AddTopic(BaseTopic topic)
    {
        _topics.Add(topic);
    }

    public void RemoveTopic(string name)
    {
        foreach (BaseTopic topic in _topics)
        {
            if (topic.Name == name)
            {
                _topics.Remove(topic);
            }
        }
    }

    public void SendMessageTo(BaseMessage baseMessage, string name)
    {
        foreach (BaseTopic topic in _topics)
        {
            if (topic.Name == name)
            {
                topic.SendMessage(baseMessage);
            }
        }
    }
}