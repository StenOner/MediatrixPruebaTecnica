using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariadoPorComision;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class CreateEmpleadoAsalariadoPorComisionInteractor(IEmpleadoRepository empleadoRepository, ICreateEmpleadoAsalariadoPorComisionOutputPort outputPort, IUnitOfWork unitOfWork) : ICreateEmpleadoAsalariadoPorComisionInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly ICreateEmpleadoAsalariadoPorComisionOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateEmpleadoAsalariadoPorComisionDto dto)
        {
            if (await _empleadoRepository.ExisteNumeroSeguroSocialAsync(dto.NumeroSeguroSocial))
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El número de seguro social ya existe")
                    );

                return;
            }

            var empleado = new EmpleadoAsalariadoPorComision
            {
                Id = Guid.NewGuid(),
                PrimerNombre = dto.PrimerNombre,
                ApellidoPaterno = dto.ApellidoPaterno,
                NumeroSeguroSocial = dto.NumeroSeguroSocial,
                Departamento = dto.Departamento,
                SalarioBase = dto.SalarioBase,
                VentasBrutas = dto.VentasBrutas,
                TarifaComision = dto.TarifaComision,
                Activo = true
            };

            await _empleadoRepository.AddAsync(empleado);
            await _unitOfWork.SaveChangesAsync();

            await _outputPort.Handle(
                Result<EmpleadoDto>.SuccessResult(EmpleadoUtility.MapToDto(empleado))
                );
        }
    }
}
