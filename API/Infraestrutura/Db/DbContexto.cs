using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbContexto(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        public DbSet<Administrador> Administradores { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    Perfil = "Admin"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var stringConexao = _configuration.GetConnectionString("DefaultConnection")?.ToString();

                if (!string.IsNullOrEmpty(stringConexao))
                    optionsBuilder.UseNpgsql(stringConexao);
                else
                    throw new InvalidOperationException("A string de conexão 'DefaultConnection' não está configurada.");
            }
        }
    }
}
