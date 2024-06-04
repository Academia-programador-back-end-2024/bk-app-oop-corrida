namespace Corrida; // namespace eh igual o nome do projeto

public class Apostador
{
    public string Nome { get; set; }
    public decimal Saldo;

    public Apostador()
    {
        this.Saldo = 20;
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
    TipoQuatro = 3
}
public class Corredor
{
    public string Nome { get; set; }
    public decimal DistanciaPercorrida { get; set; }

    private TipoDeMovimento TipoDeMovimento { get; set; }

    public Corredor()
    {
        Random random = new Random();
        TipoDeMovimento = (TipoDeMovimento)random.Next(0, 3);
    }

    public void Correr()
    {

    }

}



