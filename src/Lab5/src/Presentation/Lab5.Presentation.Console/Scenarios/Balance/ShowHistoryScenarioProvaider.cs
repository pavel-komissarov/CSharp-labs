using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class ShowHistoryScenarioProvaider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ShowHistoryScenarioProvaider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User?.Role == UserRole.Admin || _currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowHistoryScenario(_service);
        return true;
    }
}