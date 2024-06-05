using Corrida;

namespace CorridaTeste
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        public class CorredorTest
        {
            [Fact] 
            public void DeveUmCorredorMoverEntreZero_E_Setenta()
            {
                Corredor corredor = new Corredor();
                //var pega o tipo da direita
                decimal DistanciaPercorridaEsperadaAposMovimento = 0.7M;
                //act
                corredor.correr();

                // assert

                Assert.True(corredor.distanciaPercorrida <= DistanciaPercorridaEsperadaAposMovimento);
            }
        }
    }
}