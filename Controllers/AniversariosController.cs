using Microsoft.AspNetCore.Mvc;

using AniversariosApi.Models;
using AniversariosApi.Services;

namespace AniversariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AniversariosController : ControllerBase
    {
        private readonly AniversarioService _service;

        public AniversariosController(AniversarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.Listar());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _service.Obter(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Novo(Aniversario novo)
        {
            var criado = _service.Criar(novo);
            return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
        }

        [HttpPut("{id}")]
        public IActionResult  Atualizar(int id, Aniversario atualizado)
        {
            if (!_service.Atualizar(id, atualizado))
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (!_service.Remover(id))
                return NotFound();
            return NoContent();
        }
    }
}
