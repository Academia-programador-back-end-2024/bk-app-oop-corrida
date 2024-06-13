namespace Corrida
{
    public class CasaDeApostas
    {
        public List<Apostador> Apostadores { get; set; }
        public List<Corredor> Corredores { get; set; }
        public decimal ValorTotalDeApostas { get; set; }

        public Corredor Vencedor { get; set; }

        public CasaDeApostas(
            int numeroDeApostadores,
            int numeroDeCorredores)
        {
            Apostadores = new List<Apostador>();
            Corredores = new List<Corredor>();

            for (int i = 1; i <= numeroDeApostadores; i++)
            {
                AdicionarApostador(new Apostador($"Apostador{i}"));
            }
            for (int i = 1; i <= numeroDeCorredores; i++)
            {
                AdicionarCorredor(new Corredor($"Corredor{i}"));
            }

            ValidarApostadoresCorredores();
        }

        public CasaDeApostas()
        {
            Apostadores = new List<Apostador>();
            Corredores = new List<Corredor>();
        }

        public void AdicionarApostador(Apostador apostador)
        {
            Apostadores.Add(apostador);
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

            int possicao = 0;
            do
            {
                foreach (var corredor in Corredores)
                {
                    if (corredor.DistanciaPercorrida >= 100)
                    {
                        Vencedor = corredor;
                    }
                    corredor.Correr();
                }
            } while (Vencedor == null);

            DistribuicaoPremio();

            Corredor[] corredoresOrdenados =
                Corredores.
                OrderByDescending(c => c.DistanciaPercorrida).ToArray();

            foreach (var corredorOrdenado in corredoresOrdenados)
            {
                possicao++;
                corredorOrdenado.Posicao = possicao;
            }
        }

        private void DistribuicaoPremio()
        {
            List<Apostador> vencedores = new List<Apostador>();

            foreach (Apostador apostador in Apostadores)
            {
                if (apostador.CorredorApostado == Vencedor)
                {
                    vencedores.Add(apostador);
                }
            }
            if (vencedores.Count > 0)
            {
                decimal valorPremio = ValorTotalDeApostas / vencedores.Count;

                foreach (Apostador apostador in vencedores)
                {
                    apostador.ReceberPremio(valorPremio);
                }
            }
        }

        public void Apostar(Apostador apostador, Corredor corredor, decimal valorAposta)
        {
            apostador.Saque(valorAposta);
            ValorTotalDeApostas += valorAposta;
            apostador.CorredorApostado = corredor;
        }
    }
}
