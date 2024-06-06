namespace Corrida
{
    public class CasaAposta
    {
        public List<Apostador> apostadores = new List<Apostador>();
        public List<Corredor> corredores = new List<Corredor>();
        private decimal premioCorrida = 0;
        private int chegadaCorrida = 100;


        public void Jogar()
        {
            AdicionarCorredores();
            AdicionarApostadores();
            CriarApostas();

            List<Corredor> CorredoresGanhadores = ComecarCorrida();

            List<Apostador> ApostadoresGanhadores = VerificaGanhador(CorredoresGanhadores);

            DistribuiPremios(ApostadoresGanhadores);

            ImprimirListaFinal(ApostadoresGanhadores, CorredoresGanhadores);
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
                Console.Clear();
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
                    if (valorApostado < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível apostador menos que 0! ");
                        continue;
                    }
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
                        premioCorrida += valorApostado;
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
            Thread.Sleep(30);
        }

        private List<Apostador> VerificaGanhador(List<Corredor> corredoresGanhadores)
        {
            List<Apostador> apostadoresGanhadores = new List<Apostador>();
            foreach (var apostador in apostadores)
            {
                foreach(var ganhador in corredoresGanhadores)
                {
                    if (apostador.corredor == ganhador)
                    {
                        apostadoresGanhadores.Add(apostador);
                    }
                }
            }
            return apostadoresGanhadores;
        }

        private void DistribuiPremios(List<Apostador> ListaGanhadores)
        {
            premioCorrida = premioCorrida / ListaGanhadores.Count;

            foreach (var ganhador in ListaGanhadores )
            {
                ganhador.saldo += premioCorrida;
            }
        }

        private void ImprimirListaFinal(List<Apostador> listaApostadoresGanhadores, List<Corredor> listaCorredoresGanhadores)
        {
            if (listaCorredoresGanhadores.Count > 1)
            {
                Console.Write("Corredores vencedores: ");
            } else
            {
                Console.Write("Corredor vencedor: ");
            }
            foreach (var corredorVencedor in listaCorredoresGanhadores)
            {
                Console.WriteLine(corredorVencedor.nome);
            }

            Console.WriteLine("Colocação final corredores ");
            Console.WriteLine("-------------------------------------- ");
            foreach (var corredor in corredores)
            {
                Console.WriteLine("Nome corredor: " + corredor.nome + " | Distância: " + corredor.distanciaPercorrida);
            }

            Console.WriteLine("-------------------------------------- ");

            if (listaApostadoresGanhadores.Count > 1)
            {
                Console.Write("Apostadores vencedores: ");
            }
            else
            {
                Console.Write("Apostador vencedor: ");
            }
            foreach (var apostadorVencedor in listaApostadoresGanhadores)
            {
                Console.WriteLine(apostadorVencedor.nome);
            }

            Console.WriteLine("Saldo final apostadores ");
            Console.WriteLine("-------------------------------------- ");
            foreach (var apostador in apostadores)
            {
                Console.WriteLine("Nome apostador: " + apostador.nome + " | Saldo: " + apostador.saldo);
            }

            Console.WriteLine("-------------------------------------- ");

        }

    }


        
    
}
