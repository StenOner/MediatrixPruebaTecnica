using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorComision;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class UpdateEmpleadoPorComisionInteractor(IEmpleadoRepository empleadoRepository, IUpdateEmpleadoPorComisionOutputPort outputPort, IUnitOfWork unitOfWork) : IUpdateEmpleadoPorComisionInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IUpdateEmpleadoPorComisionOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(Guid id, UpdateEmpleadoPorComisionDto dto)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("Empleado no encontrado")
                    );

                return;
            }

            if (empleado is not EmpleadoPorComision empleadoPorComision)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El empleado no es de tipo por comision")
                    );

                return;
            }

            empleadoPorComision.PrimerNombre = dto.PrimerNombre;
            empleadoPorComision.ApellidoPaterno = dto.ApellidoPaterno;
            empleadoPorComision.Departamento = dto.Departamento;
            empleadoPorComision.VentasBrutas = dto.VentasBrutas;
            empleadoPorComision.TarifaComision = dto.TarifaComision;
            empleadoPorComision.Activo = dto.Activo;

            _empleadoRepository.Update(empleadoPorComision);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<EmpleadoDto>.SuccessResult(EmpleadoUtility.MapToDto(empleadoPorComision))
                );
        }
    }
}
