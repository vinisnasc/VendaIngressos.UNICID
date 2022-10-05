using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Service;
using VendaIngressos.Produto.Services;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizadorController : ControllerBase
    {
        private readonly IOrganizadorService _organizadorService;

        public OrganizadorController(IOrganizadorService organizadorService)
        {
            _organizadorService = organizadorService ?? throw new ArgumentNullException(nameof(organizadorService));
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovoOrganizador(OrganizadorDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _organizadorService.CadastrarOrganizador(dto);
            return Ok();
        }
    }
}