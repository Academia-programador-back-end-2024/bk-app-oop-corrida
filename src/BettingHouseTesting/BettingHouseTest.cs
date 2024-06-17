using Classes;
namespace BettingHouseTesting;
public class BettingHouseTest
{
    [Fact]
    public void ShouldRegisterAtLeastFourRunners()
    {
        // Arrange
        BettingHouse bettingHouse = new BettingHouse();
        List<string> runnerNameList = new List<string>() { "Tars", "Auden", "Case", "Cooper", "Tux" };
        int numberOfRunners = 4;

        // Act
        for (int i = 0; i < numberOfRunners; i++)
        {
            bettingHouse.RegisterRunners(runnerNameList[i], i);
        }

        // Assert
        Assert.True(bettingHouse.RunnerList.Count >= 4);
    }

    [Fact]
    public void ShouldHaveAWinner()
    {
        // Arrange
        BettingHouse bettingHouse = new BettingHouse();

        // Act
        bettingHouse.RegisterRunners("Tux", 1);
        bettingHouse.RegisterRunners("Pixie", 0);

        bettingHouse.RegisterBettors("Tiago", "Tux", 20);
        bettingHouse.RegisterBettors("Lele", "Pixie", 20);

        bettingHouse.Race();

        var raceWinner = bettingHouse.RunnerList.FirstOrDefault(r => r.IsWinner == true);

        // Assert
        Assert.True(raceWinner != null, $"{raceWinner.Name}, {raceWinner.MinSpeed}, {raceWinner.MaxSpeed}");
        Assert.True(raceWinner.Name == "Tux");
        Assert.NotEmpty(bettingHouse.BetWinners);
        foreach (Bettor bettor in bettingHouse.BetWinners)
        {
            Assert.True(bettor.Balance == 40);
        }




    }
}