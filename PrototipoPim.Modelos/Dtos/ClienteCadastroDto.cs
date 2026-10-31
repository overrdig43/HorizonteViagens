using System.ComponentModel.DataAnnotations;

namespace PrototipoPim.Modelos.Dtos;

/// <summary>Dados recebidos ao cadastrar um cliente.</summary>
public sealed class ClienteCadastroDto
{
    [Required, StringLength(120, MinimumLength = 3)]
    public string Nome { get; init; } = string.Empty;

    [Required]
    public string Cpf { get; init; } = string.Empty;

    [Required]
    public string Celular { get; init; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; init; } = string.Empty;

    [Required, MinLength(8)]
    public string Senha { get; init; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int ViagemId { get; init; }
}
