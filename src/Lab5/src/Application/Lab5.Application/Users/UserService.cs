using System.Globalization;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public async Task<UsersResult> Login(string username, string password)
    {
        Task<User?> user = _repository.FindUserByUsername(username, password);

        if (await user is null)
        {
            return UsersResult.Fail;
        }

        _currentUserManager.User = await user;
        return UsersResult.Success;
    }

    public Task Logout()
    {
        _currentUserManager.User = null;
        return Task.CompletedTask;
    }

    public async Task AddMoney(decimal amount)
    {
        if (_currentUserManager.User != null)
        {
            await _repository.UpdateBalance(_currentUserManager.User.Id, amount);

            await _repository.LogTransaction(_currentUserManager.User.Id, amount);
        }
    }

    public async Task<UsersResult> RemoveMoney(decimal amount)
    {
        if (_currentUserManager.User == null) return UsersResult.Fail;
        decimal balance = Convert.ToDecimal(
            await _repository.GetBalance(_currentUserManager.User.Id),
            CultureInfo.InvariantCulture);

        if (balance - amount <= 0) return UsersResult.Fail;
        await _repository.UpdateBalance(_currentUserManager.User.Id, -amount);
        await _repository.LogTransaction(_currentUserManager.User.Id, -amount);

        return UsersResult.Success;
    }

    public async Task<string> ShowBalance()
    {
        if (_currentUserManager.User != null)
            return await _repository.GetBalance(_currentUserManager.User.Id);

        return "User not found";
    }

    public async Task<string> ShowHistory()
    {
        if (_currentUserManager.User != null)
            return await _repository.ShowHistory(_currentUserManager.User.Id);

        return "User not found";
    }
}