using System;//Biblioteca base do C#.

//'Viagem' é a classe mãe.
//'PacoteLuxo' é a classe filha.
public class PacoteLuxo : Viagem
{
    //Propriedade exclusiva do pacote de luxo.
    public string Atracao { get; set; }
    //'base' faz com que a classe filha 'PacoteLuxo' herde caracteristicas da classe mãe.
    public PacoteLuxo(string destino, double preco, int duracaoDias, string atracao) : base(destino, preco, duracaoDias)
    {
        Atracao = atracao;
    }

    //'override' sobrescreve o método 'ExibirDetalhes()' da classe mãe,
    // expandindo-o com as informações exclusivas do 'PacoteLuxo'.
    public override void ExibirDetalhes()
    {
        Console.WriteLine("\n===PACOTE DE LUXO===");
        base.ExibirDetalhes();
        Console.WriteLine($"Atração principal: {Atracao}");
    }
}
