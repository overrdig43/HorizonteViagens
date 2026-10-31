namespace PrototipoPim.Modelos;

/// <summary>Dados de cadastro do viajante e referência ao pacote contratado.</summary>
public sealed class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    // A senha é armazenada como hash; nunca deve ser devolvida em respostas da API.
    public string SenhaHash { get; set; } = string.Empty;
    public int ViagemId { get; set; }
}
