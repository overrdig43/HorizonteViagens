using System;//Biblioteca base do C#.

//'abstract' é necessário pois o conceito 'Viagem' é genérico, apenas pessoas que adquirem 'Pacote Econômico' ou 'Pacote de Luxo'.
public abstract class Viagem
{
    //'Destino' é uma propriedade da classe mãe 'Viagem'. 
    public string Destino { get; set; }
    //'Preco' é uma propriedade da classe mãe 'Viagem'. 
    public double Preco { get; set; }
    //'DuracaoDias' é uma propriedade da classe mãe 'Viagem'. 
    public int DuracaoDias { get; set; }
    /*
    As propriedades serão as mesmas tanto para Pacotes de Luxo quanto para Pacotes Econômicos.
    No entanto, apenas o método 'ExibirDetalhes()' é sobrescrito nas classes filhas.
    É por este motivo que as propriedades não precisam de 'virtual' e 'override'
    */

    //Construtor responsável pela inicialização das propriedades da classe mãe.
    //Os valores recebidos serão passados para as classes filhas via 'base'.
    public Viagem(string destino, double preco, int duracaoDias)
    {
        Destino = destino;
        Preco = preco;
        DuracaoDias = duracaoDias;
    }
    //'virtual' permite que as classes filhas SOBRESCREVAM este método com comportamento próprio via 'override'.
    //'virtual' anda sempre junto com o 'override'.
    public virtual void ExibirDetalhes()
    {
        Console.WriteLine($"\nDestino: {Destino}");
        Console.WriteLine($"Duração: {DuracaoDias} dias");
        Console.WriteLine($"Preço: R$ {Preco:F2}");
    }
}