namespace BettorTesting;
using Classes;
public class BettorTest
{
    [Fact]
    public void ShouldHaveTwentyAsBalance()
    {
        // Arrange
        Bettor bettor = new Bettor();
        // Act - Empty

        // Assert
        Assert.True(bettor.Balance == 20);
    }
}
