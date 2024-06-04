using Corrida;

namespace CorridaTest
{
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
            Corredor corredor = new Corredor();
            // Var pega o tipo da direita
            decimal DistanciaPercorridaEsperadaAposMovimento = 0.7M;

            // Act
            corredor.Correr();

            // Assert, DistanciaPercorrida <= 0.7 && DistanciaPercorrida >= 0
            Assert.True(corredor.DistanciaPercorrida <= DistanciaPercorridaEsperadaAposMovimento && corredor.DistanciaPercorrida >= 0);

        }
    }
}