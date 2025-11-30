using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorComision;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class CreateEmpleadoPorComisionInteractor(IEmpleadoRepository empleadoRepository, ICreateEmpleadoPorComisionOutputPort outputPort, IUnitOfWork unitOfWork) : ICreateEmpleadoPorComisionInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly ICreateEmpleadoPorComisionOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateEmpleadoPorComisionDto dto)
        {
            if (await _empleadoRepository.ExisteNumeroSeguroSocialAsync(dto.NumeroSeguroSocial))
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El número de seguro social ya existe")
                    );

                return;
            }

            var empleado = new EmpleadoPorComision
            {
                Id = Guid.NewGuid(),
                PrimerNombre = dto.PrimerNombre,
                ApellidoPaterno = dto.ApellidoPaterno,
                NumeroSeguroSocial = dto.NumeroSeguroSocial,
                Departamento = dto.Departamento,
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
