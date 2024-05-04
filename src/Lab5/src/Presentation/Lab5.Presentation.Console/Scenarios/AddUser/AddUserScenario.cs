using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AddUser;

public class AddUserScenario : IScenario
{
    private IAdminService _adminService;

    public AddUserScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Add user";

    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter username");
        string pin = AnsiConsole.Ask<string>("Enter pin");

        await _adminService.Register(username, pin);

        AnsiConsole.Ask<string>("Ok");
    }
}