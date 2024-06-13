namespace Corrida; // namespace eh igual o nome do projeto

public class Corredor
{
    public string Nome { get; set; }

    //Deve percorrer 100 metros por corrida.
    public decimal DistanciaPercorrida { get; set; }

    public int Posicao { get; set; }

    private TipoDeMovimento TipodeDeMovimento { get; set; }
    private Random random { get; set; }
    public int MovimentoMin { get; private set; }
    public int MovimentoMax { get; private set; }

    public Corredor(
        string nomeCorredor = "corredor",
        TipoDeMovimento tipoDeMovimento = TipoDeMovimento.NaoDefinido)
    {
        random = new Random();
        if (tipoDeMovimento == TipoDeMovimento.NaoDefinido)
        {
            TipodeDeMovimento = (TipoDeMovimento)random.Next(0, 3);
        }
        this.Nome = nomeCorredor;
        this.DefenirMovimento();
        Posicao = 0;
    }

    private void DefenirMovimento()
    {
        switch (TipodeDeMovimento)
        {
            case TipoDeMovimento.TipoUm:
                MovimentoMin = 0;
                MovimentoMax = 70;
                break;
            case TipoDeMovimento.TipoDois:
                MovimentoMin = 30;
                MovimentoMax = 50;
                break;
            case TipoDeMovimento.TipoTres:
                MovimentoMin = 20;
                MovimentoMax = 40;
                break;
            case TipoDeMovimento.TipoQuatro:
                MovimentoMin = 10;
                MovimentoMax = 60;
                break;
        }
    }

    public void Correr()
    {
        decimal valorMovimento = random.Next(MovimentoMin, MovimentoMax);
        DistanciaPercorrida += (valorMovimento / 100);
    }

    public Corredor CriarCorredor()
    {
        Corredor corredor = new Corredor();
        return corredor;
    }

}



