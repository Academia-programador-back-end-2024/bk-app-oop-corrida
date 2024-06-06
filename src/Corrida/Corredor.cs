namespace Corrida
{
    public class Apostador
    {
        public string nome { get; set; }
        public decimal Saldo;

        public Apostador()
        {
            this.Saldo = 20;
        }
        
    }


    public enum TipoDeMovimento
    {
        tipoUm = 1,
        tipoDois = 2,
        tiposTres = 3,
        tipoQuatro = 4
    }

    public class Corredor
    {
        public string nome { get; set; }
        private TipoDeMovimento tipoDeMovimento { get; set; }
        public decimal distanciaPercorrida { get; set; }

        public Corredor()
        {
            Random random = new Random();

            tipoDeMovimento = (TipoDeMovimento)random.Next(1, 4);
        }


    }
}
