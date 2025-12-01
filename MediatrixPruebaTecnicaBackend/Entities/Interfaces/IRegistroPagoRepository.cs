using MediatrixPruebaTecnica.Entities.POCOs;

namespace MediatrixPruebaTecnica.Entities.Interfaces
{
    public interface IRegistroPagoRepository : IRepository<RegistroPago>
    {
        Task<IEnumerable<RegistroPago>> GetPagosPorEmpleadoAsync(Guid empleadoId);
        Task<IEnumerable<RegistroPago>> GetPagosPorPeriodoAsync(DateTime inicio, DateTime fin);
        Task<RegistroPago?> GetUltimoPagoEmpleadoAsync(Guid empleadoId);
    }
}
