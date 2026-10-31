using Microsoft.AspNetCore.Mvc;
using PrototipoPim.Modelos.Dtos;
using PrototipoPim.RegraDeNegocio;

namespace PrototipoPim.api.Controllers;

/// <summary>Endpoints de cadastro e consulta de clientes.</summary>
[ApiController]
[Route("api/clientes")]
public sealed class ClientesController(ClienteNegocio negocio) : ControllerBase
{
    [HttpGet]
    public IActionResult Listar() => Ok(negocio.ListarClientes());

    [HttpPost]
    public IActionResult Cadastrar([FromBody] ClienteCadastroDto dados)
    {
        try
        {
            var cliente = negocio.Cadastrar(dados);
            return Created($"/api/clientes/{cliente.Id}", cliente);
        }
        catch (RegraDeNegocioException erro)
        {
            return BadRequest(new { mensagem = erro.Message });
        }
    }
}
