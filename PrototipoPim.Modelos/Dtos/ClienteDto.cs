namespace PrototipoPim.Modelos.Dtos;

/// <summary>Visão pública do cliente, sem senha ou hash de senha.</summary>
public sealed record ClienteDto(int Id, string Nome, string Cpf, string Celular, string Email, int ViagemId);
