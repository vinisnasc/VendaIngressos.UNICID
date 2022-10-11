using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    public class OrganizadorController : BaseController
    {
        private readonly IOrganizadorService _organizadorService;

        public OrganizadorController(IOrganizadorService organizadorService)
        {
            _organizadorService = organizadorService ?? throw new ArgumentNullException(nameof(organizadorService));
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscarTodosOrganizadores()
        {
            var list = await _organizadorService.BuscarTodosOrganizadores();
            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarNovoOrganizador(OrganizadorDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _organizadorService.CadastrarOrganizador(dto);
            return Ok();
        }
    }
}