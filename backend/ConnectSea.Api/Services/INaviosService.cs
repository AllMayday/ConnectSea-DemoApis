using ConnectSea.Api.Models;
namespace ConnectSea.Api.Services {
    public interface INaviosService {
        Task<List<Navio>> GetAllAsync();
        Task<Navio?> GetByIdAsync(int id);
        Task<Navio> CreateAsync(Navio ship);
        Task UpdateAsync(int id, Navio ship);
        Task DeleteAsync(int id);
    }
}
