namespace PrototipoPim.Modelos;

/// <summary>Pacote econômico que informa a acomodação incluída.</summary>
public sealed class PacoteEconomico : Viagem
{
    public string TipoAcomodacao { get; set; } = string.Empty;
    public override string DetalhesEspecificos => $"Acomodação: {TipoAcomodacao}";
}
