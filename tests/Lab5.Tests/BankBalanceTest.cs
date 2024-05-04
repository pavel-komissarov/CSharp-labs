using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Lab5.Application.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankBalanceTest
{
    [Theory]
    [InlineData(100)]
    public async Task AddMoneyTest(decimal amount)
    {
        // Arrange
        IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();
        var currentUserManager = new CurrentUserManager();
        currentUserManager.User = new User(1, UserRole.User); // Set up a user
        var userService = new UserService(userRepositoryMock, currentUserManager);

        // Act
        await userService.AddMoney(amount);

        // Assert
        await userRepositoryMock.Received().UpdateBalance(Arg.Any<long>(), amount);
    }

    [Theory]
    [InlineData(50)]
    public async Task RemoveMoneyTest(decimal amount)
    {
        // Arrange
        IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();
        CurrentUserManager currentUserManagerMock = Substitute.For<CurrentUserManager>();
        currentUserManagerMock.User = new User(1, UserRole.User);

        var userService = new UserService(userRepositoryMock, currentUserManagerMock);

        userRepositoryMock.GetBalance(currentUserManagerMock.User.Id).Returns("100");

        // Act
        UsersResult result = await userService.RemoveMoney(amount);

        // Assert
        Assert.Equal(UsersResult.Success, result);
    }

    [Theory]
    [InlineData(100)]
    public async Task RemoveMoneyTest2(decimal amount)
    {
        // Arrange
        IUserRepository userRepositoryMock = Substitute.For<IUserRepository>();
        CurrentUserManager currentUserManagerMock = Substitute.For<CurrentUserManager>();
        currentUserManagerMock.User = new User(1, UserRole.User);

        var userService = new UserService(userRepositoryMock, currentUserManagerMock);

        userRepositoryMock.GetBalance(currentUserManagerMock.User.Id).Returns("1");

        // Act
        UsersResult result = await userService.RemoveMoney(amount);

        // Assert
        Assert.Equal(UsersResult.Fail, result);
    }
}