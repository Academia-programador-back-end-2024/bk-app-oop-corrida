/// <summary>
/// Cada corredor possui um comportamento de movimento específico.
/// Um corredor pode se mover aleatoriamente entre
/// 0 cm e 70 cm,
/// outro entre 30 cm e 50 cm,
/// outro entre 20 cm e 40 cm, 
/// e o último entre 10 cm e 60 cm. 
/// Os apostadores devem escolher em qual corredor apostar antes do início da corrida.
/// </summary>


namespace Corrida;


public enum TipoDeMovimento
{
    TipoUm = 0,
    TipoDois = 1,
    TipoTres = 2,
    TipoQuatro = 3,
    NaoDefinido = 4
}