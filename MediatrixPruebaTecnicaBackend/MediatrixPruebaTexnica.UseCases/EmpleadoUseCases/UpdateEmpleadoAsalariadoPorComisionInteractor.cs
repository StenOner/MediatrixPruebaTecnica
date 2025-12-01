using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class UpdateEmpleadoAsalariadoPorComisionPorComisionInteractor(IEmpleadoRepository empleadoRepository, IUpdateEmpleadoAsalariadoPorComisionOutputPort outputPort, IUnitOfWork unitOfWork) : IUpdateEmpleadoAsalariadoPorComisionInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IUpdateEmpleadoAsalariadoPorComisionOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(Guid id, UpdateEmpleadoAsalariadoPorComisionDto dto)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("Empleado no encontrado")
                    );

                return;
            }

            if (empleado is not EmpleadoAsalariadoPorComision empleadoAsalariadoPorComision)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El empleado no es de tipo asalariado por comision")
                    );

                return;
            }

            empleadoAsalariadoPorComision.PrimerNombre = dto.PrimerNombre;
            empleadoAsalariadoPorComision.ApellidoPaterno = dto.ApellidoPaterno;
            empleadoAsalariadoPorComision.Departamento = dto.Departamento;
            empleadoAsalariadoPorComision.SalarioBase = dto.SalarioBase;
            empleadoAsalariadoPorComision.VentasBrutas = dto.VentasBrutas;
            empleadoAsalariadoPorComision.TarifaComision = dto.TarifaComision;
            empleadoAsalariadoPorComision.Activo = dto.Activo;

            _empleadoRepository.Update(empleadoAsalariadoPorComision);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<EmpleadoDto>.SuccessResult(EmpleadoUtility.MapToDto(empleadoAsalariadoPorComision))
                );
        }
    }
}
