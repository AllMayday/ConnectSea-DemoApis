using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ConnectSea.Api.Models;
using ConnectSea.Api.Services;

namespace ConnectSea.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class NaviosController : ControllerBase {
        private readonly INaviosService _svc;
        public NaviosController(INaviosService svc) { _svc = svc; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) { var s = await _svc.GetByIdAsync(id); return s == null ? NotFound() : Ok(s); }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Navio navio) { var criado = await _svc.CreateAsync(navio); return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado); }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] Navio navio) { await _svc.UpdateAsync(id, navio); return NoContent(); }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) { await _svc.DeleteAsync(id); return NoContent(); }
    }
}
