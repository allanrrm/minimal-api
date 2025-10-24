using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servico;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTest
{

    private DbContexto CriarContextoDeTeste()
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (path == null)
        {
             Assert.Fail("Não foi possível determinar o diretório base para configuração.");
            throw new InvalidOperationException("Não foi possível determinar o diretório base para configuração.");
        }

        var testConfigPath = Path.Combine(path ?? "", "..", "..", "..");
        var configFile = File.Exists(testConfigPath) ? "appsettings.json" : "appsettings.json";

        var builder = new ConfigurationBuilder()
            .SetBasePath(testConfigPath)
            .AddJsonFile(configFile, optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        var configuration = builder.Build();

        return new DbContexto(configuration);

    }



    [TestMethod]
    public void TestandoPersistirAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Administradores\" RESTART IDENTITY;");

        var adm = new Administrador();
        adm.Email = "testa@teste.com";
        adm.Senha = "senha123";
        adm.Perfil = "Admin";
        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscarPorId(adm.Id) ?? null!;


        // Assert
        Assert.AreEqual(1, admDoBanco.Id);

    }
}