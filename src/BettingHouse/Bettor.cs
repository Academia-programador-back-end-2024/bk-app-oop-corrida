namespace Classes
{
    public class Bettor
    {
        public Guid Id = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public Runner Runner { get; set; }

        public Bettor()
        {
            Balance = 20;
        }

        public void PickARunner(List<Runner> runnerList, string runnerName)
        {
            Runner = runnerList.FirstOrDefault(r => r.Name == runnerName);
        }

        public void Bet(decimal amountToBet)
        {
            Balance -= amountToBet;
        }



    }
}
