using Microsoft.AspNetCore.Mvc;
using PrototipoPim.RegraDeNegocio;

namespace PrototipoPim.api.Controllers;

/// <summary>Endpoints de consulta dos pacotes de viagem.</summary>
[ApiController]
[Route("api/viagens")]
public sealed class ViagensController(ClienteNegocio negocio) : ControllerBase
{
    [HttpGet]
    public IActionResult Listar() => Ok(negocio.ListarViagens());
}
