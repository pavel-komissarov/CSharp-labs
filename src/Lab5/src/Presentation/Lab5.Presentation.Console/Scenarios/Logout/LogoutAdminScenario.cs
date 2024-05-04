using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LogoutAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Logout";

    public async Task Run()
    {
        await _adminService.Logout();

        AnsiConsole.Ask<string>("Ok");
    }
}