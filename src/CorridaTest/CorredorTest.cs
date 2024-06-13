using Corrida;

namespace CorridaTest;

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

    [Fact]
    //Os apostadores devem escolher em qual corredor apostar antes do início da corrida.
    public void DevePermetirApostadorApostarEmCorredor()
    {
        //Arrange
        CasaDeApostas casaDeApostas = new CasaDeApostas(5, 4);
        Apostador apostador = casaDeApostas.Apostadores[0];
        Corredor corredor = casaDeApostas.Corredores[0];
        decimal saldoEsperadoAposAposta = 10;
        decimal valorTotalDeApostasEsperado = 10;
        decimal valorParaApostar = 10;

        //Act
        casaDeApostas.Apostar(apostador, corredor, valorParaApostar);

        //Arranger
        Assert.Equal(valorTotalDeApostasEsperado, casaDeApostas.ValorTotalDeApostas);
        Assert.Equal(saldoEsperadoAposAposta, apostador.Saldo);
        Assert.Equal(corredor, apostador.CorredorApostado);
    }

    [Fact]
    //A corrida continua até que um dos corredores atinja a marca de 100 metros, sendo declarado o vencedor. 
    public void DeveFinalizarCorridaAoChegarEm100Metros()
    {
        //Arrange
        CasaDeApostas casaDeApostas = new CasaDeApostas(5, 4);
        decimal saldoEsperadoAposAposta = 10;
        decimal valorParaApostar = 10;
        Corredor corredor = casaDeApostas.Corredores[0];
        bool alguemChegouEm100 = false;

        //Act
        foreach (Apostador apostador in casaDeApostas.Apostadores)
        {
            casaDeApostas.Apostar(apostador, corredor, valorParaApostar);
            //Arranger
            Assert.Equal(saldoEsperadoAposAposta, apostador.Saldo);
            Assert.Equal(corredor, apostador.CorredorApostado);
        }

        casaDeApostas.ExecutarCorrida();


        foreach (Corredor corredorFim in casaDeApostas.Corredores)
        {
            if (corredorFim.DistanciaPercorrida >= 100)
            {
                alguemChegouEm100 = true;
            }
        }

        Assert.True(alguemChegouEm100);
    }

    [Fact]
    public void DeveFinalizarCorridaE_DeclararUmVencedor()
    {
        //Arrange
        CasaDeApostas casaDeApostas = new CasaDeApostas(5, 4);
        decimal saldoEsperadoAposAposta = 10;
        decimal valorParaApostar = 10;
        Corredor corredor = casaDeApostas.Corredores[0];
        Corredor VencedorEsperado = corredor;
        corredor.DistanciaPercorrida = 100;

        //Act
        foreach (Apostador apostador in casaDeApostas.Apostadores)
        {
            casaDeApostas.Apostar(apostador, corredor, valorParaApostar);
            //Arranger
            Assert.Equal(saldoEsperadoAposAposta, apostador.Saldo);
            Assert.Equal(corredor, apostador.CorredorApostado);
        }

        casaDeApostas.ExecutarCorrida();


        Assert.Equal(VencedorEsperado, casaDeApostas.Vencedor);
    }

    //NaoPermetirIniciarACorridaSemApostas

    //O prêmio da corrida é dividido entre os apostadores que apostaram no corredor vencedor.
    [Fact]
    public void DeveDividirO_PremioEntreOGanhadore()
    {
        //Arrange
        CasaDeApostas casaDeApostas = new CasaDeApostas(5, 4);
        decimal valorParaApostar = 10;
        Corredor corredorVencedor = casaDeApostas.Corredores[1];
        Corredor VencedorEsperado = corredorVencedor;
        corredorVencedor.DistanciaPercorrida = 100;
        Apostador apostarVencedorEsperado = casaDeApostas.Apostadores[0];
        casaDeApostas.Apostar(apostarVencedorEsperado, corredorVencedor, valorParaApostar);
        decimal saldoEsperadoVencedor = 60;

        foreach (Apostador apostador in casaDeApostas.Apostadores)
        {
            if (apostador.CorredorApostado == null)
            {
                casaDeApostas.Apostar(apostador, casaDeApostas.Corredores[0], valorParaApostar);
            }
        }

        //Act
        casaDeApostas.ExecutarCorrida();


        Assert.Equal(VencedorEsperado, casaDeApostas.Vencedor);
        Assert.Equal(saldoEsperadoVencedor, apostarVencedorEsperado.Saldo);
    }

    [Fact]
    public void DeveDividirO_PremioEntreDoisGanhadores()
    {
        //Arrange
        CasaDeApostas casaDeApostas = new CasaDeApostas(5, 4);
        decimal valorParaApostar = 10;
        Corredor corredorVencedor = casaDeApostas.Corredores[1];
        Corredor VencedorEsperado = corredorVencedor;
        corredorVencedor.DistanciaPercorrida = 100;
        Apostador apostador1VencedorEsperado = casaDeApostas.Apostadores[0];
        casaDeApostas.Apostar(apostador1VencedorEsperado, corredorVencedor, valorParaApostar);
        decimal saldoEsperadoVencedor = 35;

        Apostador apostador2VencedorEsperado = casaDeApostas.Apostadores[1];
        casaDeApostas.Apostar(apostador2VencedorEsperado, corredorVencedor, valorParaApostar);


        foreach (Apostador apostador in casaDeApostas.Apostadores)
        {
            if (apostador.CorredorApostado == null)
            {
                casaDeApostas.Apostar(apostador, casaDeApostas.Corredores[0], valorParaApostar);
            }
        }

        //Act
        casaDeApostas.ExecutarCorrida();


        Assert.Equal(VencedorEsperado, casaDeApostas.Vencedor);
        Assert.Equal(saldoEsperadoVencedor, apostador1VencedorEsperado.Saldo);

        Assert.Equal(saldoEsperadoVencedor, apostador1VencedorEsperado.Saldo);
        Assert.Equal(saldoEsperadoVencedor, apostador2VencedorEsperado.Saldo);
    }

    //o sistema deve exibir a colocação final de todos os corredores
    [Fact]
    public void DeveDefinirAcolocacaoDeTodosOsCorredores()
    {
        //Arrange
        CasaDeApostas casaDeApostas = new CasaDeApostas(5, 4);
        decimal valorParaApostar = 10;
        Corredor corredorPrimeiro = casaDeApostas.Corredores[2];
        corredorPrimeiro.DistanciaPercorrida = 100;

        Corredor corredorSegundo = casaDeApostas.Corredores[3];
        corredorSegundo.DistanciaPercorrida = 95;

        Corredor corredorTerceiro = casaDeApostas.Corredores[1];
        corredorTerceiro.DistanciaPercorrida = 88;

        Corredor corredorQuarto = casaDeApostas.Corredores[0];
        corredorQuarto.DistanciaPercorrida = 77;

        foreach (Apostador apostador in casaDeApostas.Apostadores)
        {
            casaDeApostas.Apostar(apostador, corredorPrimeiro, valorParaApostar);
        }

        //Act
        casaDeApostas.ExecutarCorrida();

        Assert.Equal(corredorPrimeiro.Posicao, 1);
        Assert.Equal(corredorSegundo.Posicao, 2);
        Assert.Equal(corredorTerceiro.Posicao, 3);
        Assert.Equal(corredorQuarto.Posicao, 4);
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
