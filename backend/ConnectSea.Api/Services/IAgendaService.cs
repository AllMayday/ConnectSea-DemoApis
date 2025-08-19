using ConnectSea.Api.Models;
namespace ConnectSea.Api.Services {
    public interface IAgendaService {
        Task<List<Agenda>> ListAsync(DateTime? from=null, DateTime? to=null, int? berthId=null);
        Task<Agenda?> GetByIdAsync(int id);
        Task<Agenda> CreateAsync(Agenda schedule);
        Task UpdateAsync(int id, Agenda schedule);
        Task DeleteAsync(int id);
    }
}
