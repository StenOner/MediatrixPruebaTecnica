using MediatrixPruebaTecnica.Entities.Bases;

namespace MediatrixPruebaTecnica.Entities.Interfaces
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {
        Task<IEnumerable<Empleado>> GetEmpleadosActivosAsync();
        Task<IEnumerable<Empleado>> GetEmpleadosPorDepartamentoAsync(string departamento);
        Task<Empleado?> GetEmpleadoConPagosAsync(Guid id);
        Task<bool> ExisteNumeroSeguroSocialAsync(string numeroSeguroSocial, Guid? empleadoId = null);
        Task<IEnumerable<Empleado>> BuscarEmpleadosAsync(string? nombre, string? departamento, bool? activo);
    }
}
