using Classes;

namespace RunnerTest
{
    public class RunnerTest
    {
        [Fact]
        public void ShouldRunBetweenZeroSeventy()
        {
            // Arrange
            var runner = new ZeroSeventyRunner();
            runner.Name = "Tars";

            // Act
            runner.Run(); // Should be between 0 and 0.7

            // Assert
            Assert.True(runner.TotalDistance >= 0 && runner.TotalDistance <= 0.7m, $"{runner.TotalDistance}");
        }

        [Fact]
        public void ShouldRunBetweenThirtyFifty()
        {
            // Arrange
            var runner = new ThirtyFiftyRunner();
            runner.Name = "Murph";

            // Act
            runner.Run(); // Should be between 0.3 and 0.5

            // Assert
            Assert.True(runner.TotalDistance >= 0.3m && runner.TotalDistance <= 0.5m, $"{runner.TotalDistance}");
        }

        [Fact]
        public void ShouldRunBetweenTwentyForty()
        {
            // Arrange
            var runner = new TwentyFortyRunner();
            runner.Name = "Cooper";

            // Act
            runner.Run(); // Should be between 0.2 and 0.4

            // Assert
            Assert.True(runner.TotalDistance >= 0.2m && runner.TotalDistance <= 0.4m, $"{runner.TotalDistance}");
        }

        [Fact]
        public void ShouldRunBetweenTenSixty()
        {
            // Arrange
            var runner = new TenSixtyRunner();
            runner.Name = "Brand";

            // Act
            runner.Run(); // Should be between 0.1 and 0.6

            // Assert
            Assert.True(runner.TotalDistance >= 0.1m && runner.TotalDistance <= 0.6m, $"{runner.TotalDistance}");
        }
    }
}
