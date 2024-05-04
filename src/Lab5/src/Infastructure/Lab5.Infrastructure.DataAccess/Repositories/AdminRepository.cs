using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task Register(string username, string password)
    {
        const string sql = """
                           insert into users (user_name, user_password, user_role)
                            values (:username, hashtext(:pin), :role)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("pin", password)
            .AddParameter("username", username)
            .AddParameter("role", UserRole.User);

        await command.ExecuteNonQueryAsync();
    }

    public async Task CreateBalance(string username)
    {
        const string sql =
            """
            insert into balances (user_id, balance)
            select user_id, 0
            from users
            where user_name = :username
            """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("username", username);

        await command.ExecuteNonQueryAsync();
    }
}