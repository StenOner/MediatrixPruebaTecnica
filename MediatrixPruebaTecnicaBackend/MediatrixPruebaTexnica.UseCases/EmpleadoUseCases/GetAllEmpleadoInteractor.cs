using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class GetAllEmpleadoInteractor(IEmpleadoRepository empleadoRepository, IGetAllEmpleadoOutputPort outputPort) : IGetAllEmpleadoInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IGetAllEmpleadoOutputPort _outputPort = outputPort;

        public async Task Handle()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            var dtos = empleados.Select(EmpleadoUtility.MapToDto);

            await _outputPort.Handle(
                Result<IEnumerable<EmpleadoDto>>.SuccessResult(dtos)
                );
        }
    }
}
