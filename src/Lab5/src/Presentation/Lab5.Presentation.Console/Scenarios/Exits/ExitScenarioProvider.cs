using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.Exits;

public class ExitScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;

    public ExitScenarioProvider(
        ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ExitScenario();
        return true;
    }
}