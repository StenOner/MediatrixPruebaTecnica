using MediatrixPruebaTecnica.Entities.POCOs;

namespace MediatrixPruebaTecnica.Entities.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByNombreUsuarioAsync(string nombreUsuario);
        Task<Usuario?> GetUsuarioConRolAsync(Guid id);
        Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario, Guid? usuarioId = null);
    }
}
