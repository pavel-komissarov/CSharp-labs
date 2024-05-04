using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    [Theory]
    [InlineData(5, 5, 50)]
    [InlineData(10, 10, 100)]
    public void FailFly(int simplefuel, int jumpjuel, int distance)
    {
        // Arrange
        BaseShip walker = new Walker(simplefuel);
        BaseShip avgur = new Avgur(simplefuel, jumpjuel);
        BaseInvironments nebula = new NebulaeHighDensity(distance, new Flash(0));

        // Act
        nebula.Fly(walker);
        nebula.Fly(avgur);

        // Assert
        Assert.False(new CheckShipOnResult().IsSuccess(walker));
        Assert.False(new CheckShipOnResult().IsSuccess(avgur));
    }

    [Theory]
    [InlineData(50, 50, 50)]
    [InlineData(100, 100, 100)]
    public void FlashTest(int simplefuel, int jumpjuel, int distance)
    {
        // Arrange
        BaseShip vaklas1 = new Vaklas(simplefuel, jumpjuel);
        BaseShip vaklas2 = new Vaklas(simplefuel, jumpjuel, true);
        BaseInvironments nebula = new NebulaeHighDensity(distance, new Flash(3));

        // Act
        nebula.Fly(vaklas1);
        nebula.Fly(vaklas2);

        // Assert
        Assert.True(new CheckShipOnResult().IsDie(vaklas1));
        Assert.False(new CheckShipOnResult().IsDie(vaklas2));
    }

    [Theory]
    [InlineData(50, 50, 50)]
    [InlineData(100, 100, 100)]
    public void WhalsesTest(int simplefuel, int jumpjuel, int distance)
    {
        // Arrange
        BaseShip vaklas = new Vaklas(simplefuel, jumpjuel);
        BaseShip avgur = new Avgur(simplefuel, jumpjuel);
        BaseShip meredian = new Meredian(simplefuel);

        BaseInvironments nebula = new NebulaeNitrineParticle(distance, new Whalses(2));
        BaseInvironments nebula1 = new NebulaeNitrineParticle(distance, new Whalses(1));
        BaseInvironments nebula2 = new NebulaeNitrineParticle(distance, new Whalses(0));

        // Act
        nebula.Fly(vaklas);
        nebula1.Fly(avgur);
        nebula2.Fly(meredian);

        // Assert
        Assert.True(new CheckShipOnResult().IsCrash(vaklas));
        Assert.False(new CheckShipOnResult().IsCrash(avgur) && avgur.Armory != 0);
        Assert.Equal(0, meredian.Armory - meredian.MaxArmor);
    }

    [Theory]
    [InlineData(100, 10)]
    [InlineData(50, 5)]
    public void RouteTestWalker(int simplefuel, int distance)
    {
        // Arrange
        BaseShip walker = new Walker(simplefuel);
        BaseShip vaklas = new Vaklas(simplefuel);

        BaseInvironments space = new SimpleSpace(distance, new Asteroids(0));

        var ships = new List<BaseShip>() { vaklas, walker };
        var invironments = new List<BaseInvironments>() { space };

        var route = new FlightCounting();

        // Act
        SuccessResultFly? result = route.BestShip(ships, invironments);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Walker>(result.Ship);
    }

    [Theory]
    [InlineData(50, 100, 40)]
    [InlineData(100, 80, 30)]
    public void RouteTestStella(int simplefuel, int jumpjuel, int distance)
    {
        // Arrange
        BaseShip avgur = new Avgur(simplefuel, jumpjuel);
        BaseShip stella = new Stella(simplefuel, jumpjuel);

        BaseInvironments nebulae = new NebulaeHighDensity(distance, new Flash(0));

        var ships = new List<BaseShip>() { avgur, stella };
        var invironments = new List<BaseInvironments>() { nebulae };

        var route = new FlightCounting();

        // Act
        SuccessResultFly? result = route.BestShip(ships, invironments);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Stella>(result.Ship);
    }

    [Theory]
    [InlineData(50, 50, 110)]
    [InlineData(100, 100, 100)]
    public void TestNebulaNitrine(int simplefuel, int jumpjuel, int distance)
    {
        // Arrange
        BaseShip walker = new Walker(simplefuel);
        BaseShip vaklas = new Vaklas(simplefuel, jumpjuel);

        BaseInvironments nebulae = new NebulaeNitrineParticle(distance, new Whalses(0));

        var ships = new List<BaseShip>() { walker, vaklas };
        var invironments = new List<BaseInvironments>() { nebulae };

        var route = new FlightCounting();

        // Act
        SuccessResultFly? result = route.BestShip(ships, invironments);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Vaklas>(result.Ship);
    }

    [Theory]
    [InlineData(180, 50, 110, 30)]
    [InlineData(400, 100, 100, 40)]
    public void TestRoute(int simplefuel, int jumpjuel, int distance, int distance2)
    {
        // Arrange
        BaseShip stella = new Stella(simplefuel, jumpjuel, true);

        BaseInvironments nebulaenitrine = new NebulaeNitrineParticle(distance, new Whalses(0));
        BaseInvironments nebulaehight = new NebulaeHighDensity(distance2, new Flash(2));
        BaseInvironments space = new SimpleSpace(distance, new Asteroids(3));

        var ships = new List<BaseShip>() { stella };
        var invironments = new List<BaseInvironments>() { space, nebulaehight, nebulaenitrine };

        var route = new FlightCounting();

        // Act
        IEnumerable<BaseShip> result = route.FlyAnalizes(ships, invironments);

        // Assert
        Assert.False(new CheckShipOnResult().IsCrash(result.First()));
    }
}