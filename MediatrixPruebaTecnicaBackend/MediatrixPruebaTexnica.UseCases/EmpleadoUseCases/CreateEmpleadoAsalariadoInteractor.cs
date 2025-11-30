using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariado;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class CreateEmpleadoAsalariadoInteractor(IEmpleadoRepository empleadoRepository, ICreateEmpleadoAsalariadoOutputPort outputPort, IUnitOfWork unitOfWork) : ICreateEmpleadoAsalariadoInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly ICreateEmpleadoAsalariadoOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateEmpleadoAsalariadoDto dto)
        {
            if (await _empleadoRepository.ExisteNumeroSeguroSocialAsync(dto.NumeroSeguroSocial))
            {
                await _outputPort.Handle(
                    Result<EmpleadoDto>.FailureResult("El número de seguro social ya existe")
                    );

                return;
            }

            var empleado = new EmpleadoAsalariado
            {
                Id = Guid.NewGuid(),
                PrimerNombre = dto.PrimerNombre,
                ApellidoPaterno = dto.ApellidoPaterno,
                NumeroSeguroSocial = dto.NumeroSeguroSocial,
                Departamento = dto.Departamento,
                SalarioSemanal = dto.SalarioSemanal,
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
