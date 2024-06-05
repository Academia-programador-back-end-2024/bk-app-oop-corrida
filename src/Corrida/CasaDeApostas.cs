namespace Corrida
{
    public class CasaDeApostas
    {
        public List<Apostador> Apostadores { get; set; }
        public List<Corredor> Corredores { get; set; }

        public CasaDeApostas(
            int numeroDeApostadores,
            int numeroDeCorredores)
        {
            Apostadores = new List<Apostador>();
            Corredores = new List<Corredor>();

            for (int i = 1; i <= numeroDeApostadores; i++)
            {
                Apostadores.Add(new Apostador($"Apostador{i}"));
            }
            for (int i = 1; i <= numeroDeCorredores; i++)
            {
                Corredores.Add(new Corredor($"Corredor{i}"));
            }

            ValidarApostadoresCorredores();
        }

        public CasaDeApostas()
        {
            Apostadores = new List<Apostador>();
            Corredores = new List<Corredor>();
        }

        public void AdicionarCorredor(Corredor corredor)
        {
            Corredores.Add(corredor);
        }

        public void ValidarApostadoresCorredores()
        {
            if (Apostadores.Count < 5)
            {
                throw new Exception("O número mínimo de apostadores é 5");
            }

            if (Corredores.Count < 4)
            {
                throw new Exception("O número mínimo de apostadores é 5");
            }
        }

        public void ExecutarCorrida()
        {
            do
            {

            } while (ValidarDistanciaCorredores());
        }

        private bool ValidarDistanciaCorredores()
        {
            foreach (var corredor in Corredores)
            {
                corredor.Correr();
                if (corredor.DistanciaPercorrida < 100)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
