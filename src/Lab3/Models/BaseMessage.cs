using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class BaseMessage
{
    public BaseMessage(string? title, string? body, SeverityLevel? severityLevel)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Body = body ?? throw new ArgumentNullException(nameof(body));
        SeverityLevel = severityLevel ?? throw new ArgumentNullException(nameof(severityLevel));
    }

    public string Title { get; init; }
    public string Body { get; init; }
    public SeverityLevel SeverityLevel { get; init; }
}