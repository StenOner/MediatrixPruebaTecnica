using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariado;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class UpdateEmpleadoAsalariadoInteractor(IEmpleadoRepository empleadoRepository, IUpdateEmpleadoAsalariadoOutputPort outputPort, IUnitOfWork unitOfWork) : IUpdateEmpleadoAsalariadoInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IUpdateEmpleadoAsalariadoOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(Guid id, UpdateEmpleadoAsalariadoDto dto)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("Empleado no encontrado")
                    );

                return;
            }

            if (empleado is not EmpleadoAsalariado empleadoAsalariado)
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El empleado no es de tipo asalariado")
                    );
                
                return;
            }

            empleadoAsalariado.PrimerNombre = dto.PrimerNombre;
            empleadoAsalariado.ApellidoPaterno = dto.ApellidoPaterno;
            empleadoAsalariado.Departamento = dto.Departamento;
            empleadoAsalariado.SalarioSemanal = dto.SalarioSemanal;
            empleadoAsalariado.Activo = dto.Activo;

            _empleadoRepository.Update(empleadoAsalariado);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<EmpleadoDto>.SuccessResult(EmpleadoUtility.MapToDto(empleadoAsalariado))
                );
        }
    }
}
