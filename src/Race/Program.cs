namespace Race;
using Classes;
class Program
{
    static void Main(string[] args)
    {
        BettingHouse bettingHouse = new BettingHouse();
        bettingHouse.AskForNames(true);
        bettingHouse.AskForNames(false);
        bettingHouse.Race();
    }
}
