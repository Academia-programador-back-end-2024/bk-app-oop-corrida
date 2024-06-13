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