namespace MediatrixPruebaTecnica.Entities.POCOs
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        public Guid RolId { get; set; }
        public Rol Rol { get; set; } = null!;

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
    }
}
