using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    public class AtracaoController : BaseController
    {
        private readonly IAtracaoService _atracaoService;

        public AtracaoController(IAtracaoService atracaoService, INotificador notificador) : base(notificador)
        {
            _atracaoService = atracaoService ?? throw new ArgumentNullException(nameof(atracaoService));
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscarTodasAtracoes()
        {
            return CustomResponse(await _atracaoService.BuscarTodasAtracoes());
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            return CustomResponse(await _atracaoService.BuscarAtracaoPorId(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CadastrarNovaAtracao(AtracaoCreate dto)
        {
            if (!ModelState.IsValid) return CustomResponse(dto);

            string imgName = dto.Nome + Guid.NewGuid() + ".jpg";

            if(!UploadArquivo(dto.PosterUpload, imgName))
            {
                return CustomResponse();
            }
            dto.Poster = imgName;

            await _atracaoService.CriarAtracao(dto);

            return CustomResponse(dto);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if(string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para esse evento!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);
            var filePath = Path.Combine(Directory.GetCurrentDirectory().Replace("Produto.API", "WebApp.MVC").Replace("services\\Produto", "web"), "wwwroot/imagens", imgNome);

            if(System.IO.File.Exists(filePath))
            {
                NotificarErro("já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}