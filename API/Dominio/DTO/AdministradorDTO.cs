using minimalapi.Dominio.Enuns;

namespace MinimalApi.Dominio.DTO
{
    public record AdministradorDTO
    {
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
        public Perfil? Perfil { get; set; } = default!;

    }
}