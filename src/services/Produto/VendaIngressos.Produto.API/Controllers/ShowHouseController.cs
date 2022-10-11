using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    public class ShowHouseController : BaseController
    {
        private readonly IShowHouseService _showHouseService;

        public ShowHouseController(IShowHouseService showHouseService)
        {
            _showHouseService = showHouseService ?? throw new ArgumentNullException(nameof(showHouseService));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarShowHouse(ShowHouseDTO dto)
        {
            await _showHouseService.CriarCasaDeShows(dto);
            return Ok();
        }
    }
}