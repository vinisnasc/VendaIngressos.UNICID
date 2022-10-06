using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtracaoController : ControllerBase
    {
        private readonly IAtracaoService _atracaoService;

        public AtracaoController(IAtracaoService atracaoService)
        {
            _atracaoService = atracaoService ?? throw new ArgumentNullException(nameof(atracaoService));
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodasAtracoes()
        {
            return Ok(await _atracaoService.BuscarTodasAtracoes());
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarNovaAtracao(AtracaoDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _atracaoService.CriarAtracao(dto);

            return Ok();
        }
    }
}