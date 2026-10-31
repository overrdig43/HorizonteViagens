using System;//Biblioteca base do C#.

//'Viagem' é a classe mãe.
//'PacoteEconomico' é a classe filha.
public class PacoteEconomico : Viagem
{
    //Propriedade exclusiva do tipo economico.
    public string TipoAcomodacao { get; set; }
    //'base' repassa os parâmetros comuns para o construtor da classe mãe 'Viagem'.
    public PacoteEconomico(string destino, double preco, int duracaoDias, string tipoAcomodacao) : base(destino, preco, duracaoDias)
    {
        TipoAcomodacao = tipoAcomodacao;
    }

    //'override' sobrescreve o método 'ExibirDetalhes()' da classe mãe,
    // expandindo-o com as informações exclusivas do 'PacoteEconomico'.
    public override void ExibirDetalhes()
    {
        Console.WriteLine("\n===PACOTE ECONÔMICO===");
        //'base.ExibirDetalhes()' chama o método da classe mãe para aproveitar
        // a exibição das propriedades comuns antes de adicionar 'TipoAcomodacao'.
        base.ExibirDetalhes();
        Console.WriteLine($"Acomodação: {TipoAcomodacao}");
    }

}
