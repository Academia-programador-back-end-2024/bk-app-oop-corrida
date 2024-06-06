namespace Corrida; // namespace eh igual o nome do projeto

public class Apostador
{
    public string Nome { get; set; }
    public decimal Saldo;
    public Corredor CorredorApostado { get; set; }

    public Apostador(string nomeApostador = "")
    {
        this.Saldo = 20;
        this.Nome = nomeApostador;
    }

    public void Saque(decimal saque)
    {
        Saldo -= saque;
    }

    public void ReceberPremio(decimal premio)
    {
        Saldo += premio;
    }
}

// Tipos de movimento do corredor
/// <summary>
/// Cada corredor possui um comportamento de movimento específico.
/// Um corredor pode se mover aleatoriamente entre
/// 0 cm e 70 cm,
/// outro entre 30 cm e 50 cm,
/// outro entre 20 cm e 40 cm, 
/// e o último entre 10 cm e 60 cm. 
/// Os apostadores devem escolher em qual corredor apostar antes do início da corrida.
/// </summary>
public enum TipoDeMovimento
{
    TipoUm = 0,
    TipoDois = 1,
    TipoTres = 2,
    TipoQuatro = 3,
    NaoDefinido = 4
}
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



