namespace Corrida
{
    public class TipoMovimento
    {
        private int min;
        private int max;

        public TipoMovimento()
        {
            Random rnd = new();
            int tipo = rnd.Next(1, 4);

            switch (tipo)
            {
                case 1:
                    min = 0;
                    max = 70;
                    break;
                case 2:
                    min = 30;
                    max = 50;
                    break;
                case 3:
                    min = 20;
                    max = 40;
                    break;
                case 4:
                    min = 10;
                    max = 60;
                    break;
            }
        }

        public decimal Mover()
        {
            Random rnd = new();
            decimal dist = rnd.Next(min, max);
            return  dist / 100;
        }

    }


        
    
}
