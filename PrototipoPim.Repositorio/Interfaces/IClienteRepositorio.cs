using PrototipoPim.Modelos;

namespace PrototipoPim.Repositorio.Interfaces;

/// <summary>Define operações de persistência dos cadastros de clientes.</summary>
public interface IClienteRepositorio
{
    IReadOnlyList<Cliente> Listar();
    Cliente? BuscarPorId(int id);
    bool EmailJaCadastrado(string email);
    Cliente Adicionar(Cliente cliente);
}
