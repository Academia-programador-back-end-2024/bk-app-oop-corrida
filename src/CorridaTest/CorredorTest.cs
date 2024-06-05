using Corrida;

namespace CorridaTest
{
    public class CasaDeApostasTest
    {
        [Fact]
        public void DeveTerNoMinimoCincoApostadoresNaCasaDeApostas()
        {
            //A
            CasaDeApostas casaDeApostas = new CasaDeApostas(5, 4);
            int expectedCorredores = 4;
            int expectedApostadores = 5;

            //A
            Assert.Equal(expectedCorredores, casaDeApostas.Corredores.Count);
            Assert.Equal(expectedApostadores, casaDeApostas.Apostadores.Count);
        }

        [Fact]
        public void NaoDeveCriarCasaDeApostaComQuatroApostadores()
        {
            //A
            try
            {
                CasaDeApostas casaDeApostas = new CasaDeApostas(4, 4);
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.Message, "O número mínimo de apostadores é 5");
            }
        }
    }
    public class ApostadorTest
    {
        [Fact]
        public void DeveTerSaldoDeVinteReais()
        {
            Apostador apostador = new Apostador();
            decimal SaldoEsperado = 20;

            // Classe
            Assert.Equal(SaldoEsperado, apostador.Saldo);
        }

    }

    public class CorredorTest
    {
        [Fact]
        public void DeveUmCorredorMoverEntreZeroESetenta()
        {
            Corredor corredor = new Corredor(
                tipoDeMovimento: TipoDeMovimento.TipoUm);
            int movimentoMinEsperado = 0;
            int movimentoMaxEsperado = 70;

            // Var pega o tipo da direita
            decimal DistanciaPercorridaEsperadaAposMovimento = 0.7M;

            // Act
            corredor.Correr();

            // Assert, DistanciaPercorrida <= 0.7 && DistanciaPercorrida >= 0
            Assert.True(corredor.DistanciaPercorrida <= DistanciaPercorridaEsperadaAposMovimento && corredor.DistanciaPercorrida >= 0);
            Assert.Equivalent(movimentoMaxEsperado, corredor.MovimentoMax);
            Assert.Equivalent(movimentoMinEsperado, corredor.MovimentoMin);

        }
    }
}