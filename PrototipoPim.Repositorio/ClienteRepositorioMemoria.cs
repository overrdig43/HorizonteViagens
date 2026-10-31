using PrototipoPim.Modelos;
using PrototipoPim.Repositorio.Interfaces;

namespace PrototipoPim.Repositorio;

/// <summary>Persistência temporária em memória, adequada ao protótipo sem banco configurado.</summary>
public sealed class ClienteRepositorioMemoria : IClienteRepositorio
{
    private readonly List<Cliente> _clientes = [];
    private int _proximoId = 1;

    public IReadOnlyList<Cliente> Listar() => _clientes.AsReadOnly();
    public Cliente? BuscarPorId(int id) => _clientes.FirstOrDefault(c => c.Id == id);
    public bool EmailJaCadastrado(string email) => _clientes.Any(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    public Cliente Adicionar(Cliente cliente)
    {
        cliente.Id = _proximoId++;
        _clientes.Add(cliente);
        return cliente;
    }
}
