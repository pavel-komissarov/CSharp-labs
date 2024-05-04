using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUsername(string number, string pin);
    Task<string> GetBalance(long id);
    Task UpdateBalance(long id, decimal amount);
    Task LogTransaction(long id, decimal amount);
    Task<string> ShowHistory(long id);
}