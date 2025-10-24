using minimalapi.Dominio.Enuns;

namespace MinimalApi.Dominio.DTO.ModelViews
{
    public record AdministradorLogado

    {
       public string Email { get; set; } = default!;
       public string Perfil { get; set; } = default!;
       public string Token { get; set; } = default!;
    }
}