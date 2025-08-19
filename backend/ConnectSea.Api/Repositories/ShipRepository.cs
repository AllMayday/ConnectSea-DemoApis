using Microsoft.EntityFrameworkCore;
using ConnectSea.Api.Data;
using ConnectSea.Api.Models;

namespace ConnectSea.Api.Repositories {
    public class ShipRepository : INaviosRepository {
        private readonly PortoDbContext _db;
        public ShipRepository(PortoDbContext db) { _db = db; }
        public async Task<List<Navio>> GetAllAsync() => await _db.Navios.AsNoTracking().ToListAsync();
        public async Task<Navio?> GetByIdAsync(int id) => await _db.Navios.FindAsync(id);
        public async Task<Navio> CreateAsync(Navio ship) { _db.Navios.Add(ship); await _db.SaveChangesAsync(); return ship; }
        public async Task UpdateAsync(Navio ship) { _db.Navios.Update(ship); await _db.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var s = await _db.Navios.FindAsync(id); if (s!=null) { _db.Navios.Remove(s); await _db.SaveChangesAsync(); } }
    }
}
