namespace Corrida
{
    public class Corredor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public TipoMovimento tipoMovimento;
        public decimal distanciaPercorrida;

        public Corredor(string nome)
        {
            this.nome = nome;
            tipoMovimento = new();
        }

        public void Mover()
        {
            distanciaPercorrida += tipoMovimento.Mover();
        }
    }


        
    
}
