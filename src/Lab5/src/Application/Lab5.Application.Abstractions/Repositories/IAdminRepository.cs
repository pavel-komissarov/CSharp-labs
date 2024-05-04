namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task Register(string username, string password);

    Task CreateBalance(string username);
}