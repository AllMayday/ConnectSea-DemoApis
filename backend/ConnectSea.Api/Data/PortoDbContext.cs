using Microsoft.EntityFrameworkCore;
using ConnectSea.Api.Models;

namespace ConnectSea.Api.Data {
    public class PortoDbContext : DbContext {
        public PortoDbContext(DbContextOptions<PortoDbContext> opts) : base(opts) {}
        public DbSet<Navio> Navios => Set<Navio>();
        public DbSet<Berco> Bercos => Set<Berco>();
        public DbSet<Agenda> Agendas => Set<Agenda>();
        public DbSet<Carga> Cargas => Set<Carga>();
        public DbSet<Usuario> Users => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Navio>().HasIndex(s => s.NumeroIMO).IsUnique(false);
            modelBuilder.Entity<Agenda>().HasOne(s => s.Navio).WithMany().HasForeignKey(s => s.NavioId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Agenda>().HasOne(s => s.Berco).WithMany().HasForeignKey(s => s.BercoId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public static class DataSeeder {
        public static void Seed(PortoDbContext db) {
            if (db.Navios.Any()) return;
            var navios = new List<Navio> {
                new Navio { Nome = "Sonho Intenso", NumeroIMO = "IMO1", Bandeira = "BR", Tonelagem = 15000 },
                new Navio { Nome = "Home of the Brave", NumeroIMO = "IMO2", Bandeira = "US", Tonelagem = 22000 },
                new Navio { Nome = "Herói do Mar", NumeroIMO = "IMO3", Bandeira = "PT", Tonelagem = 9000 },
                new Navio { Nome = "Qian Jin", NumeroIMO = "IMO4", Bandeira = "CN", Tonelagem = 9700 },
            };
            db.Navios.AddRange(navios);
            var bercos = new List<Berco> {
                new Berco { Nome = "Berth A", DraftMaximo = 12.5m, LoaMaximo = 300m },
                new Berco { Nome = "Berth B", DraftMaximo = 10.0m, LoaMaximo = 220m },
                new Berco { Nome = "Berth C", DraftMaximo = 8.0m, LoaMaximo = 180m }
            };
            db.Bercos.AddRange(bercos);
            db.SaveChanges();
            var agendas = new List<Agenda> {
                new Agenda { NavioId = navios[0].Id, BercoId = bercos[0].Id, Chegada = DateTime.UtcNow.AddDays(1), Partida = DateTime.UtcNow.AddDays(2), Status = "Planejada" },
                new Agenda { NavioId = navios[1].Id, BercoId = bercos[1].Id, Chegada = DateTime.UtcNow.AddDays(2), Partida = DateTime.UtcNow.AddDays(3), Status = "Planejada" },
                new Agenda { NavioId = navios[2].Id, BercoId = bercos[0].Id, Chegada = DateTime.UtcNow.AddDays(1).AddHours(12), Partida = DateTime.UtcNow.AddDays(2).AddHours(12), Status = "Planejada" }
            };
            db.Agendas.AddRange(agendas);
            var cargas = new List<Carga> {
                new Carga { AgendaId = agendas[0].Id, Descricao = "Equipamento em Container", PesoEmKg = 12000, Tipo = "container" },
                new Carga { AgendaId = agendas[1].Id, Descricao = "Grãos", PesoEmKg = 30000, Tipo = "Alimentos" }
            };
            db.Cargas.AddRange(cargas);
            db.Users.Add(new Usuario { Username = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Demo@123"), Role = "Admin" });
            db.Users.Add(new Usuario { Username = "operator", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Demo@123"), Role = "Operator" });
            db.SaveChanges();
        }
    }
}
