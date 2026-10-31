namespace PrototipoPim.Modelos;

/// <summary>Pacote premium que inclui uma atração principal.</summary>
public sealed class PacoteLuxo : Viagem
{
    public string Atracao { get; set; } = string.Empty;
    public override string DetalhesEspecificos => $"Atração principal: {Atracao}";
}
