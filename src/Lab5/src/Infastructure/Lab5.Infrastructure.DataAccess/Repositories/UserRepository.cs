using System.Globalization;
using System.Text;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUsername(string number, string pin)
    {
        const string sql = """
                           select user_id, user_name, user_role
                           from users
                           where user_name = @username and user_password = hashtext(@pin)
                           """;

        if (string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(pin))
        {
            return null;
        }

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", number).AddParameter("pin", pin);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
        {
            return null;
        }

        return new User(
            reader.GetInt32(0),
            await reader.GetFieldValueAsync<UserRole>(2));
    }

    public async Task<string> GetBalance(long id)
    {
        const string sql = """
                           select balance
                           from balances
                           where user_id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
        {
            return "Can't find user";
        }

        return reader.GetDecimal(0).ToString(CultureInfo.InvariantCulture);
    }

    public async Task UpdateBalance(long id, decimal amount)
    {
        const string sql = """
                           update balances
                           set balance = balance + :amount
                           where user_id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("amount", amount);

        await command.ExecuteNonQueryAsync();
    }

    public async Task LogTransaction(long id, decimal amount)
    {
        const string sql = """
                           insert into transactions (user_id, amount, transaction_date)
                           values (:id, :amount, :date)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("date", DateTime.Now);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<string> ShowHistory(long id)
    {
        const string sql = """
                           select transaction_date, amount
                           from transactions
                           where user_id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var result = new StringBuilder();

        while (await reader.ReadAsync())
        {
            DateTime transactionDate = reader.GetDateTime(0);
            decimal amount = reader.GetDecimal(1);

            result.AppendLine(CultureInfo.InvariantCulture, $"Date: {transactionDate}, Amount: {amount}");
        }

        if (result.Length == 0)
        {
            return "Can't find user";
        }

        return result.ToString();
    }
}