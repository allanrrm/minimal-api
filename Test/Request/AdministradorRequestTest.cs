using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Test.Helpers;
using MinimalApi.Dominio.DTO;
using MinimalApi.Dominio.DTO.ModelViews;
using MinimalApi.Dominio.Entidades;

namespace Test.Request.Entidades;

[TestClass]
public sealed class AdministradorRequestTest
{

    [ClassInitialize] //Inicia o teste uma vez antes de todos os métodos

    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }

    [ClassCleanup] //Finaliza o teste uma vez depois de todos os métodoss
    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }

    [TestMethod]
    public async Task TestarGetSetPropriedades()
    {
        // Arrange
        var loginDTO = new LoginDTO
        {
            Email = "adm@teste.com",
            Senha = "senha123"
        };

        var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");


        // Act
        var response = await Setup.client.PostAsync($"/administradores/login", content);



        // Assert
        Assert.AreEqual(200, response.StatusCode.GetHashCode());

        var result = await response.Content.ReadAsStringAsync();
        var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.IsNotNull(admLogado?.Email);
        Assert.IsNotNull(admLogado?.Perfil ?? "");
        Assert.IsNotNull(admLogado?.Token ?? "");


    }
}
