using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorHoras;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class CreateEmpleadoPorHorasInteractor(IEmpleadoRepository empleadoRepository, ICreateEmpleadoPorHorasOutputPort outputPort, IUnitOfWork unitOfWork) : ICreateEmpleadoPorHorasInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly ICreateEmpleadoPorHorasOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateEmpleadoPorHorasDto dto)
        {
            if (await _empleadoRepository.ExisteNumeroSeguroSocialAsync(dto.NumeroSeguroSocial))
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El número de seguro social ya existe")
                    );

                return;
            }

            var empleado = new EmpleadoPorHoras
            {
                Id = Guid.NewGuid(),
                PrimerNombre = dto.PrimerNombre,
                ApellidoPaterno = dto.ApellidoPaterno,
                NumeroSeguroSocial = dto.NumeroSeguroSocial,
                Departamento = dto.Departamento,
                SueldoPorHora = dto.SueldoPorHora,
                HorasTrabajadas = dto.HorasTrabajadas,
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
