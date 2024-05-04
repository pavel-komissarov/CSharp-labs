using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TestCorporateMessageDistributionSystem
{
    [Theory]
    [InlineData("Test")]
    public void TestMessageNotRead(string name)
    {
        // Arrange
        var message = new BaseMessage(name, "Hello, world!", SeverityLevel.Low);

        var user = new User();
        var addresseeUser = new AddresseeUser(user);

        var topic = new Topic(name, addresseeUser);

        var system = new CorporateMessageDistributionSystem(new List<BaseTopic> { topic });

        // Act
        system.SendMessageTo(message, name);

        // Assert
        Assert.False(user.Messages.First().Read);
    }

    [Theory]
    [InlineData("Test")]
    public void TestMessageRead(string name)
    {
        // Arrange
        var message = new BaseMessage(name, "Hello, world!", SeverityLevel.Low);

        var user = new User();
        var addresseeUser = new AddresseeUser(user);

        var topic = new Topic(name, addresseeUser);

        var system = new CorporateMessageDistributionSystem(new List<BaseTopic> { topic });

        // Act
        system.SendMessageTo(message, name);
        user.CheckMessage(name);

        // Assert
        Assert.True(user.Messages.First().Read);
    }

    [Theory]
    [InlineData("Test")]
    public void TestMessageReadException(string name)
    {
        // Arrange
        var message = new BaseMessage(name, "Hello, world!", SeverityLevel.Low);

        var user = new User();
        var addresseeUser = new AddresseeUser(user);

        var topic = new Topic(name, addresseeUser);

        var system = new CorporateMessageDistributionSystem(new List<BaseTopic> { topic });

        // Act
        system.SendMessageTo(message, name);
        user.CheckMessage(name);

        try
        {
            user.CheckMessage(name);
        }
        catch (MessageCantBeReadException e)
        {
            // Assert
            Assert.Equal("Cant read because message already read!", e.Message);
        }
    }

    [Theory]
    [InlineData("Test")]
    public void TestFilter(string name)
    {
        // Arrange
        int counter = 0;

        var mockUser = new Mock<IUser>();
        mockUser.Setup(user => user.GetMessage(It.IsAny<BaseMessage>())).Callback(() => counter++);

        var message = new BaseMessage(name, "Hello, world!", SeverityLevel.Low);

        var addresseeUser = new AddresseeUser(mockUser.Object);
        var addresseeUserProxy = new AddresseeWithFilter(addresseeUser, SeverityLevel.High);

        var topic = new Topic(name, addresseeUserProxy);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Equal(0, counter);
    }

    [Theory]
    [InlineData("Test")]
    public void TestLogger(string name)
    {
        // Arrange
        int counter = 0;

        var mockLogger = new Mock<ILogger>();
        mockLogger.Setup(logger => logger.Write(It.IsAny<string>())).Callback(() => counter++);

        var message = new BaseMessage(name, "Hello, world!", SeverityLevel.Low);

        var user = new User();
        var addresseeUser = new AddresseeUser(user);
        var addresseeUserProxy = new AddresseeWithFilter(addresseeUser, SeverityLevel.High);
        var addressUserDecorator = new AddresseeWithLog(addresseeUserProxy, mockLogger.Object);

        var topic = new Topic(name, addressUserDecorator);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Equal(1, counter);
    }

    [Theory]
    [InlineData("Test")]
    public void TestMessenger(string name)
    {
        // Arrange
        int counterTelegram = 0;
        int counterLogger = 0;

        var mockTelegram = new Mock<ITelegram>();
        mockTelegram.Setup(messenger => messenger.PostMessage(It.IsAny<string>())).Callback(() => counterTelegram++);

        var mockLogger = new Mock<ILogger>();
        mockLogger.Setup(logger => logger.Write(It.IsAny<string>())).Callback(() => counterLogger++);

        var message = new BaseMessage(name, "Hello, world!", SeverityLevel.High);

        var addresseeUser = new AddresseeMessenger(new TelegramAdepter(mockTelegram.Object));
        var addresseeUserProxy = new AddresseeWithFilter(addresseeUser, SeverityLevel.Medium);
        var addressUserDecorator = new AddresseeWithLog(addresseeUserProxy, mockLogger.Object);

        var topic = new Topic(name, addressUserDecorator);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Equal(1, counterLogger);
        Assert.Equal(1, counterTelegram);
    }
}