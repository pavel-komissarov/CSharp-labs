using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'user'
        );

        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null UNIQUE,
            user_password numeric not null ,
            user_role user_role not null
        );

        create table balances
        (
            user_id bigint not null references users(user_id),
            balance numeric not null
        );

        create table transactions
        (
            user_id bigint not null references users(user_id),
            amount numeric not null ,
            transaction_date timestamp not null
        );

        insert into users  (user_name, user_password, user_role) values ('admin', hashtext('admin'), 'admin');
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table transactions;
        drop table balances;
        drop table users;
        drop type user_role;
        """;
}