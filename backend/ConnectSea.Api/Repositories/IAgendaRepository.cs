using ConnectSea.Api.Models;
namespace ConnectSea.Api.Repositories {
    public interface IAgendaRepository {
        Task<List<Agenda>> GetAllAsync(DateTime? from = null, DateTime? to = null, int? berthId = null);
        Task<Agenda?> GetByIdAsync(int id);
        Task<Agenda> CreateAsync(Agenda schedule);
        Task UpdateAsync(Agenda schedule);
        Task DeleteAsync(int id);
        Task<bool> AgendaSobrepoeAsync(int berthId, DateTime arrival, DateTime departure);
    }
}
