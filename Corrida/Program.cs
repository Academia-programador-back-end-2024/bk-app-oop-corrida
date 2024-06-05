using System.Security.Cryptography.X509Certificates;

namespace Corrida
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CasaAposta casaAposta = new CasaAposta();

            casaAposta.Jogar();
        }
    }

    public class Apostador
    {
        public int id;
        public string nome;
        public Corredor corredor;
        public decimal saldo;
        public decimal valorApostado;

        public Apostador(string nome)
        {
            this.nome = nome;
            saldo = 20;
        }

        public void Apostar(Corredor corredor, decimal valor)
        {
            this.corredor = corredor;
            valorApostado = valor;
        }
    }

    public class Corredor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public TipoMovimento tipoMovimento;
        public int distanciaPercorrida;

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

        public int Mover()
        {
            Random rnd = new();
            return rnd.Next(min, max);
        }

    }

    public class CasaAposta
    {
        public List<Apostador> apostadores = new List<Apostador>();
        public List<Corredor> corredores = new List<Corredor>();

        private int chegadaCorrida = 100;


        public void Jogar()
        {
            AdicionarCorredores();
            AdicionarApostadores();
            CriarApostas();

            List<Corredor> ganhadores = ComecarCorrida();

            foreach(var ganhador in ganhadores)
            {
                Console.WriteLine(ganhador.nome);
            }
        }

        private void AdicionarApostadores()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Nome do apostador ");
                string nome = Console.ReadLine();

                apostadores.Add(new Apostador(nome));

                if (apostadores.Count >= 5)
                {
                    Console.WriteLine("Deseja adicionar mais apostadores? s/n ");
                    char resp = Convert.ToChar(Console.ReadLine());

                    if (resp == 's')
                    {
                        continue;
                    } else
                    {
                        break;
                    }
                }


            } while (true);
            
        }
        private void AdicionarCorredores()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Nome do corredor ");
                string nome = Console.ReadLine();

                corredores.Add(new Corredor(nome));

                if (corredores.Count >= 4)
                {
                    Console.WriteLine("Deseja adicionar mais corredores? s/n ");
                    char resp = Convert.ToChar(Console.ReadLine());

                    if (resp == 's')
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }


            } while (true);

        }
        private void CriarApostas()
        {
            foreach (Apostador apostador in apostadores)
            {
                while (true)
                {
                    ImprimirCorredores();

                    Console.WriteLine($"Digite o nome do cachorro para o apostador {apostador.nome}");
                    string cachorroAposta = Console.ReadLine();
                    if (!VerificaCachorro(cachorroAposta))
                    {
                        Console.Clear();
                        Console.WriteLine("Cachorro não encontrado.");
                        continue;
                    }
                    
                    Console.WriteLine($"Digite o valor a ser apostado, saldo disponivel: {apostador.saldo}");
                    decimal valorApostado = Convert.ToDecimal(Console.ReadLine());

                    if (valorApostado > apostador.saldo)
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível apostar mais que o saldo disponível");
                        continue;
                    }
                    else
                    {
                        Corredor corredor = AchaCorredor(cachorroAposta);
                        apostador.Apostar(corredor, valorApostado);
                        Console.Clear();
                        break;
                    }

                    
                }
            }
        }
        private void ImprimirCorredores()
        {
            foreach (var corredor in corredores)
            {
                Console.WriteLine($"Corredor de nome '{corredor.nome}'");
            }
        }
        private bool VerificaCachorro(string nomeCachorro)
        {
            foreach (var corredor in corredores)
            {
                if (corredor.nome == nomeCachorro)
                {
                    return true;
                }
            }
            return false;
        }
        private Corredor AchaCorredor(string nomeCorredor)
        {
            foreach (var corredor in corredores)
            {
                if (corredor.nome == nomeCorredor)
                {
                    return corredor;
                }
            }
            return null;
        }
        private List<Corredor> ComecarCorrida()
        {
            List<Corredor> ganhadores = new();
            while (true) 
            {
                foreach (var corredor in corredores)
                {
                    corredor.Mover();

                    if (corredor.distanciaPercorrida >= chegadaCorrida)
                    {
                        ganhadores.Add(corredor);
                    }
                }
                ImprimeCorrida();
                if (ganhadores.Count > 0)
                {
                    return ganhadores;
                }
            }
        }

        private void ImprimeCorrida()
        {
            Console.Clear();
            for (int i = 0; i <= 100; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            foreach(var corredor in corredores)
            {
                Console.Write(corredor.distanciaPercorrida);
                for (int i = 0; i < corredor.distanciaPercorrida; i++)
                {
                    Console.Write(".");
                }
                Console.WriteLine(corredor.nome);
            }
            for (int i = 0; i <= 100; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Thread.Sleep(1000);
        }





    }


        
    
}
