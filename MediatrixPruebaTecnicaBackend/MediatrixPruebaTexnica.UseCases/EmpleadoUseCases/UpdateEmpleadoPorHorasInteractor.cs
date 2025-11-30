using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorHoras;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class UpdateEmpleadoPorHorasInteractor(IEmpleadoRepository empleadoRepository, IUpdateEmpleadoPorHorasOutputPort outputPort, IUnitOfWork unitOfWork) : IUpdateEmpleadoPorHorasInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IUpdateEmpleadoPorHorasOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(Guid id, UpdateEmpleadoPorHorasDto dto)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("Empleado no encontrado")
                    );

                return;
            }

            if (empleado is not EmpleadoPorHoras empleadoPorHoras)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El empleado no es de tipo por horas")
                    );

                return;
            }

            empleadoPorHoras.PrimerNombre = dto.PrimerNombre;
            empleadoPorHoras.ApellidoPaterno = dto.ApellidoPaterno;
            empleadoPorHoras.Departamento = dto.Departamento;
            empleadoPorHoras.SueldoPorHora = dto.SueldoPorHora;
            empleadoPorHoras.HorasTrabajadas = dto.HorasTrabajadas;
            empleadoPorHoras.Activo = dto.Activo;

            _empleadoRepository.Update(empleadoPorHoras);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<EmpleadoDto>.SuccessResult(EmpleadoUtility.MapToDto(empleadoPorHoras))
                );
        }
    }
}
