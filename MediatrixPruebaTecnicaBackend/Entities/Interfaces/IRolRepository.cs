using MediatrixPruebaTecnica.Entities.POCOs;

namespace MediatrixPruebaTecnica.Entities.Interfaces
{
    public interface IRolRepository : IRepository<Rol>
    {
        Task<Rol?> GetByNombreAsync(string nombre);
    }
}
