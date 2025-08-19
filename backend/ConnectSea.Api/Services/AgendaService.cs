using ConnectSea.Api.Models;
using ConnectSea.Api.Repositories;

namespace ConnectSea.Api.Services {
    public class AgendaService : IAgendaService {
        private readonly IAgendaRepository _repo;
        public AgendaService(IAgendaRepository repo) { _repo = repo; }
        public Task<List<Agenda>> ListAsync(DateTime? from=null, DateTime? to=null, int? berthId=null) => _repo.GetAllAsync(from, to, berthId);
        public Task<Agenda?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public async Task<Agenda> CreateAsync(Agenda agenda) {
            if (agenda.Chegada >= agenda.Partida) throw new ArgumentException("Chegada deve ser anterior à partida");
            var agendaInvalida = await _repo.AgendaSobrepoeAsync(agenda.BercoId, agenda.Chegada, agenda.Partida);
            if (agendaInvalida) throw new InvalidOperationException("Agenda inválida. Já há outra agenda para este período neste berço");
            return await _repo.CreateAsync(agenda);
        }
        public async Task UpdateAsync(int id, Agenda agenda) {

            var agendaPreUpdate = await _repo.GetByIdAsync(id);

            if (agendaPreUpdate==null) throw new KeyNotFoundException("404 - Agenda não encontrada");

            if (agenda.Chegada >= agenda.Partida) throw new ArgumentException("Chegada deve ser anterior à partida");

            var agendaInvalida = await _repo.AgendaSobrepoeAsync(agenda.BercoId, agenda.Chegada, agenda.Partida);

            if (agendaInvalida && !(agendaPreUpdate.BercoId==agenda.BercoId && agendaPreUpdate.Chegada==agenda.Chegada && agendaPreUpdate.Partida==agenda.Partida)) 
                throw new InvalidOperationException("Agenda inválida. Já há outra agenda para este período neste berço");

            agendaPreUpdate.NavioId = agenda.NavioId; agendaPreUpdate.BercoId = agenda.BercoId; agendaPreUpdate.Chegada = agenda.Chegada; agendaPreUpdate.Partida = agenda.Partida; agendaPreUpdate.Status = agenda.Status;
            await _repo.UpdateAsync(agendaPreUpdate);
        }
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
