using Microsoft.AspNetCore.Mvc;
using PrototipoPim.RegraDeNegocio;

namespace PrototipoPim.web.Controllers;

/// <summary>Carrega os pacotes do negócio para a página MVC.</summary>
public sealed class ViagensController(ClienteNegocio negocio) : Controller
{
    public IActionResult Index() => View(negocio.ListarViagens());
}
