

using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infraestructure.Db;

public class DataBaseContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly  IConfiguration _configurationAppSettings;
    public DataBaseContext(IConfiguration configurationAppSettings)
    {
        _configurationAppSettings = configurationAppSettings;
    }
    public DbSet<Administrator> Administradores { get; set; } = default!;


    // Responsavel por inserir um registro de uma tabela na criação ou atualização do Banco de Dados (Seed).
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>().HasData(
            new Administrator {
                Id = 1,
                Email = "administrador@teste.com",
                Password = "123456",
                Profile = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
        var stringConexao = _configurationAppSettings.GetConnectionString("mysql")?.ToString();
        if (!string.IsNullOrEmpty(stringConexao))
        {
            optionsBuilder.UseMySql(
                stringConexao, 
                ServerVersion.AutoDetect(stringConexao));
        }
        }
        
    }
}