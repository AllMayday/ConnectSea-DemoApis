using ConnectSea.Api.Models;
namespace ConnectSea.Api.Repositories {
    public interface INaviosRepository {
        Task<List<Navio>> GetAllAsync();
        Task<Navio?> GetByIdAsync(int id);
        Task<Navio> CreateAsync(Navio ship);
        Task UpdateAsync(Navio ship);
        Task DeleteAsync(int id);
    }
}
