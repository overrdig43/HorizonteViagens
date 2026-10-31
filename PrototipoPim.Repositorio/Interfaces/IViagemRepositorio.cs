using PrototipoPim.Modelos;

namespace PrototipoPim.Repositorio.Interfaces;

/// <summary>Define operações de leitura dos pacotes disponíveis.</summary>
public interface IViagemRepositorio
{
    IReadOnlyList<Viagem> Listar();
    Viagem? BuscarPorId(int id);
}
