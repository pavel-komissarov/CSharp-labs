namespace Lab5.Application.Contracts.Users;

public interface IAdminService
{
    Task Logout();
    Task Register(string username, string password);
}