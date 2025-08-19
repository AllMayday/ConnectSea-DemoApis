using ConnectSea.Api.Models;
using ConnectSea.Api.Repositories;

namespace ConnectSea.Api.Services {
    public class NaviosService : INaviosService {
        private readonly INaviosRepository _repo;
        public NaviosService(INaviosRepository repo) { _repo = repo; }
        public Task<List<Navio>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Navio?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Navio> CreateAsync(Navio ship) => _repo.CreateAsync(ship);
        public async Task UpdateAsync(int id, Navio ship) 
        { 
            var existing = await _repo.GetByIdAsync(id); 
            if (existing == null) throw new KeyNotFoundException("Navio não encontrado. Por favor verifique o id do navio informado"); 
            existing.Nome = ship.Nome; 
            existing.NumeroIMO = ship.NumeroIMO; 
            existing.Bandeira = ship.Bandeira; 
            existing.Tonelagem = ship.Tonelagem; 
            await _repo.UpdateAsync(existing); 
        }
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
