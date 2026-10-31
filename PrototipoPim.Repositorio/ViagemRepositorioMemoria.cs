using PrototipoPim.Modelos;
using PrototipoPim.Repositorio.Interfaces;

namespace PrototipoPim.Repositorio;

/// <summary>Fornece os seis pacotes apresentados no programa original do grupo.</summary>
public sealed class ViagemRepositorioMemoria : IViagemRepositorio
{
    private readonly List<Viagem> _viagens =
    [
        new PacoteLuxo { Id = 1, Destino = "Paris - França", Preco = 15000m, DuracaoDias = 15, Atracao = "Torre Eiffel" },
        new PacoteLuxo { Id = 2, Destino = "Tokyo - Japão", Preco = 18000m, DuracaoDias = 20, Atracao = "Monte Fuji" },
        new PacoteLuxo { Id = 3, Destino = "Nova York - EUA", Preco = 12000m, DuracaoDias = 10, Atracao = "Central Park" },
        new PacoteEconomico { Id = 4, Destino = "Porto Seguro - Brasil", Preco = 4500m, DuracaoDias = 10, TipoAcomodacao = "Trancoso" },
        new PacoteEconomico { Id = 5, Destino = "Ubatuba - Brasil", Preco = 3200m, DuracaoDias = 7, TipoAcomodacao = "Praia de Itamambuca" },
        new PacoteEconomico { Id = 6, Destino = "Florianópolis - Brasil", Preco = 5500m, DuracaoDias = 8, TipoAcomodacao = "Praia dos Açores" }
    ];

    public IReadOnlyList<Viagem> Listar() => _viagens.AsReadOnly();
    public Viagem? BuscarPorId(int id) => _viagens.FirstOrDefault(v => v.Id == id);
}
