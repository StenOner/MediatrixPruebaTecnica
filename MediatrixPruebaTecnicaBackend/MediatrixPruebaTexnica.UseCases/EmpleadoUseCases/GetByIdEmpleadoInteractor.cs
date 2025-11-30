using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class GetByIdEmpleadoInteractor(IEmpleadoRepository empleadoRepository, IGetByIdEmpleadoOutputPort outputPort): IGetByIdEmpleadoInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IGetByIdEmpleadoOutputPort _outputPort = outputPort;

        public async Task Handle(Guid id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("Empleado no encontrado")
                    );

                return;
            }

            await _outputPort.Handle(
                Result<EmpleadoDto>.SuccessResult(EmpleadoUtility.MapToDto(empleado))
                );
        }
    }
}
