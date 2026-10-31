namespace PrototipoPim.Modelos;

/// <summary>Representa um pacote de viagem e reúne os dados comuns às modalidades.</summary>
public abstract class Viagem
{
    public int Id { get; set; }
    public string Destino { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int DuracaoDias { get; set; }

    // As classes derivadas acrescentam seus próprios dados ao resumo do pacote.
    public abstract string DetalhesEspecificos { get; }
}
