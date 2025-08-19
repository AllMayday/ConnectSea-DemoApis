using Microsoft.EntityFrameworkCore;
using ConnectSea.Api.Data;
using ConnectSea.Api.Models;

namespace ConnectSea.Api.Repositories {
    public class AgendaRepository : IAgendaRepository {
        private readonly PortoDbContext _db;
        public AgendaRepository(PortoDbContext db) { _db = db; }
        public async Task<List<Agenda>> GetAllAsync(DateTime? dataInicio = null, DateTime? dataFim = null, int? bercoId = null) 
        {
            var q = _db.Agendas.Include(s => s.Navio).Include(s => s.Berco).AsQueryable();

            if (dataInicio.HasValue) 
                q = q.Where(s => s.Chegada >= dataInicio.Value);

            if (dataFim.HasValue) 
                q = q.Where(s => s.Partida <= dataFim.Value);

            if (bercoId.HasValue) 
                q = q.Where(s => s.BercoId == bercoId.Value);

            return await q.AsNoTracking().ToListAsync();
        }
        public async Task<Agenda?> GetByIdAsync(int id) => await _db.Agendas.Include(s=>s.Navio).Include(s=>s.Berco).FirstOrDefaultAsync(s=>s.Id==id);
        public async Task<Agenda> CreateAsync(Agenda schedule) 
        { 
            _db.Agendas.Add(schedule); 
            await _db.SaveChangesAsync(); 
            return schedule; 
        }
        public async Task UpdateAsync(Agenda schedule) 
        {
            _db.Agendas.Update(schedule); 
            await _db.SaveChangesAsync(); 
        }
        public async Task DeleteAsync(int id) 
        { 
            var s = await _db.Agendas.FindAsync(id); 
            if (s!=null) 
            { 
                _db.Agendas.Remove(s); 
                await _db.SaveChangesAsync();
            } 
        }
        public async Task<bool> AgendaSobrepoeAsync(int berthId, DateTime arrival, DateTime departure) 
        {
            return await _db.Agendas.AnyAsync(s => s.BercoId == berthId && s.Chegada < departure && arrival < s.Partida);
        }
    }
}
