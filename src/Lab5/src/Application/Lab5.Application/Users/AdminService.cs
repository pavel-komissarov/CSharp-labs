using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;

namespace Lab5.Application.Users;

public class AdminService : IAdminService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly IAdminRepository _repository;

    public AdminService(CurrentUserManager currentUserManager, IAdminRepository repository)
    {
        _currentUserManager = currentUserManager;
        _repository = repository;
    }

    public Task Logout()
    {
        _currentUserManager.User = null;
        return Task.CompletedTask;
    }

    public async Task Register(string username, string password)
    {
        await _repository.Register(username, password);
        await _repository.CreateBalance(username);
    }
}