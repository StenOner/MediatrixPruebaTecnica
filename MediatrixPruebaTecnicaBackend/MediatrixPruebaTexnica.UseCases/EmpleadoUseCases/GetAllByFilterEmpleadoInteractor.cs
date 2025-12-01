using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllByFilterEmpleado;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class GetAllByFilterEmpleadoInteractor(IEmpleadoRepository empleadoRepository, IGetAllByFilterEmpleadoOutputPort outputPort) : IGetAllByFilterEmpleadoInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IGetAllByFilterEmpleadoOutputPort _outputPort = outputPort;

        public async Task Handle(EmpleadoFiltroDto dto)
        {
            var empleados = await _empleadoRepository.BuscarEmpleadosAsync(
                dto.Nombre,
                dto.Departamento,
                dto.Activo
            );
            var dtos = empleados.Select(EmpleadoUtility.MapToDto);

            await _outputPort.Handle(
                Result<IEnumerable<EmpleadoDto>>.SuccessResult(dtos)
                );
        }
    }
}
