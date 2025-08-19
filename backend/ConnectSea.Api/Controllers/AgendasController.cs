using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ConnectSea.Api.Models;
using ConnectSea.Api.Services;

namespace ConnectSea.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AgendasController : ControllerBase {
        private readonly IAgendaService _svc;
        public AgendasController(IAgendaService svc) { _svc = svc; }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null, [FromQuery] int? berthId = null) {
            return Ok(await _svc.ListAsync(from, to, berthId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) { var s = await _svc.GetByIdAsync(id); return s==null? NotFound() : Ok(s); }

        [HttpPost]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Create([FromBody] Agenda schedule) {
            try {
                var created = await _svc.CreateAsync(schedule);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            } catch (ArgumentException ex) {
                return BadRequest(new { error = ex.Message });
            } catch (InvalidOperationException ex) {
                return Conflict(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Update(int id, [FromBody] Agenda schedule) {
            try { await _svc.UpdateAsync(id, schedule); return NoContent(); } catch (Exception ex) when (ex is KeyNotFoundException) { return NotFound(); } catch (ArgumentException ex) { return BadRequest(new { error = ex.Message }); } catch (InvalidOperationException ex) { return Conflict(new { error = ex.Message }); }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) { await _svc.DeleteAsync(id); return NoContent(); }
    }
}
