namespace Corrida
{
    public class Apostador
    {
        public int id;
        public string nome;
        public Corredor corredor;
        public decimal saldo;

        public Apostador(string nome)
        {
            this.nome = nome;
            saldo = 20;
        }

        public void Apostar(Corredor corredor, decimal valor)
        {
            this.corredor = corredor;
            saldo -= valor;
        }

        public void ReceberPremio(decimal valor)
        {
            saldo += valor;
        }
    }


        
    
}
