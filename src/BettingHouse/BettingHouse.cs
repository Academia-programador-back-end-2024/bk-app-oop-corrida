namespace Classes
{
    public class BettingHouse
    {
        public List<Runner> RunnerList { get; set; }
        public List<Bettor> BettorList { get; set; }
        public Runner Winner { get; set; }
        public List<Bettor> BetWinners { get; set; }
        public decimal BetPool { get; set; }

        public BettingHouse()
        {
            RunnerList = new List<Runner>() { };
            BettorList = new List<Bettor>() { };
            BetWinners = new List<Bettor>() { };
            Winner = null;
            BetPool = 0;
        }

        public void AskForNames(bool runners)
        {

            if (runners)
            {
                Console.WriteLine("How many runners do you want to register?: ");
                int numberOfRunners = int.Parse(Console.ReadLine());
                while (RunnerList.Count != numberOfRunners)
                {
                    Console.WriteLine("Insert a name and a type for the runner:\n");
                    string runnerName = Console.ReadLine();
                    Console.WriteLine("Available types:\n0: 0-0.7\n1: 0.3-0.5\n2: 0.2-0.4\n3: 0.1-0.6\n");
                    int runnerType = int.Parse(Console.ReadLine());
                    RegisterRunners(runnerName, runnerType);
                }
            }

            if (!runners)
            {
                Console.WriteLine("How many Bettors do you want to register?: ");
                int numberOfBettors = int.Parse(Console.ReadLine());
                while (BettorList.Count != numberOfBettors)
                {
                    Console.WriteLine("Insert a name for the bettor:\n");
                    string bettorName = Console.ReadLine();
                    Console.WriteLine("Available runners:\n");
                    for (int i = 0; i < RunnerList.Count; i++)
                    {
                        Console.WriteLine(RunnerList[i].Name);
                    }
                    Console.WriteLine("\nChoose a runner from the options above:\n");
                    string runnerName = Console.ReadLine();
                    Console.WriteLine("How much would you like to bet?\n");
                    decimal amountToBet = decimal.Parse(Console.ReadLine());
                    RegisterBettors(bettorName, runnerName, amountToBet);
                }
            }
        }

        public void RegisterRunners(string name, int runnerType)
        {
            List<Runner> runnerTypeList = new List<Runner>() { new ZeroSeventyRunner(), new ThirtyFiftyRunner(), new TwentyFortyRunner(), new TenSixtyRunner() };
            var runner = runnerTypeList.ElementAt(runnerType);
            runner.Name = name;
            Console.WriteLine("\nSuccessfully registered the runner!\n");
            Console.WriteLine($"Runner id: {runner.Id}\n");
            Console.WriteLine($"Runner name: {runner.Name}\n");
            Console.WriteLine($"His minimal speed is {runner.MinSpeed} and his maximum speed is {runner.MaxSpeed}\n");
            RunnerList.Add(runner);
        }

        public void RegisterBettors(string name, string runnerName, decimal amountToBet)
        {
            Bettor bettor = new Bettor();
            bettor.Name = name;
            bettor.PickARunner(RunnerList, runnerName);
            Console.WriteLine("How much would you like to bet: ");
            bettor.Bet(amountToBet);
            BetPool += amountToBet;
            Console.WriteLine($"Your current balance: {bettor.Balance}");
            Console.WriteLine($"Current pool: {BetPool}");
            BettorList.Add(bettor);
            Console.WriteLine($"\nSuccessfully added a bettor called {bettor.Name}\n");
            Console.WriteLine($"{bettor.Runner.Name}");
        }

        public void Race()
        {
            var winner = RunnerList.FirstOrDefault(r => r.IsWinner);
            while (winner == null)
            {
                for (int i = 0; i < RunnerList.Count; i++)
                {
                    RunnerList[i].Run();
                    if (RunnerList[i].TotalDistance >= 100)
                    {
                        RunnerList[i].IsWinner = true;
                        winner = RunnerList[i];
                        Winner = winner; // Runner is a property of the class
                    }
                }
            }
            CheckForWinners();

        }

        public void CheckForWinners()
        {
            foreach (Bettor bettor in BettorList)
            {
                if (bettor.Runner.Name == Winner.Name)
                {
                    BetWinners.Add(bettor);
                }
            }
            SharePrize();

        }
        public void SharePrize()
        {
            decimal prize = BetPool / BetWinners.Count;
            foreach (Bettor bettor in BetWinners)
            {
                bettor.Balance = prize;
                Console.WriteLine($"Winner: {bettor.Name}, New Balance: {bettor.Balance}");
            }
        }
    }
}
