namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    Task<UsersResult> Login(string username, string password);
    Task Logout();
    Task AddMoney(decimal amount);
    Task<UsersResult> RemoveMoney(decimal amount);
    Task<string> ShowBalance();
    Task<string> ShowHistory();
}