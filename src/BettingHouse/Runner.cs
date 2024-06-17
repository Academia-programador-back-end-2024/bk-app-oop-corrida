namespace Classes
{
    public class Runner
    {
        public Guid Id = Guid.NewGuid();
        public string Name { get; set; }
        public decimal MinSpeed { get; set; }
        public decimal MaxSpeed { get; set; }
        public decimal TotalDistance { get; set; }
        public bool IsWinner { get; set; }

        public Runner()
        {
            Id = Guid.NewGuid();
            TotalDistance = 0;
            IsWinner = false;
        }

        public void Run()
        {
            int minSpeedToInt = (int)(MinSpeed * 10);
            int maxSpeedToInt = (int)(MaxSpeed * 10);
            Random random = new Random();
            int CoveredIntegerDistance = random.Next(minSpeedToInt, (maxSpeedToInt + 1)); // The plus one is necessary because of the way .Next works
            TotalDistance += (decimal)CoveredIntegerDistance / 10;
        }

        public bool HasWon()
        {
            if (TotalDistance >= 100)
            {
                return true;
            }
            return false;
        }

    }

    public class ZeroSeventyRunner : Runner
    {
        public ZeroSeventyRunner()
        {
            MinSpeed = 0.0m;
            MaxSpeed = 0.7m;
        }
    }

    public class ThirtyFiftyRunner : Runner
    {
        public ThirtyFiftyRunner()
        {
            MinSpeed = 0.3m;
            MaxSpeed = 0.5m;
        }
    }

    public class TwentyFortyRunner : Runner
    {
        public TwentyFortyRunner()
        {
            MinSpeed = 0.2m;
            MaxSpeed = 0.4m;
        }
    }

    public class TenSixtyRunner : Runner
    {
        public TenSixtyRunner()
        {
            MinSpeed = 0.1m;
            MaxSpeed = 0.6m;
        }
    }
}
