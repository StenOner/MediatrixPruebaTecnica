using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago;

namespace MediatrixPruebaTexnica.UseCases.RegistroPagoUseCases
{
    public class CreateRegistroPagoInteractor(IRegistroPagoRepository registroPagoRepository, IEmpleadoRepository empleadoRepository, ICreateRegistroPagoOutputPort outputPort, IUnitOfWork unitOfWork)
        : ICreateRegistroPagoInputPort
    {
        private readonly IRegistroPagoRepository _registroPagoRepository = registroPagoRepository;
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly ICreateRegistroPagoOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateRegistroPagoDto dto)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(dto.EmpleadoId);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<RegistroPagoDto>.FailureResult("Empleado no encontrado")
                    );

                return;
            }

            var montoBruto = empleado.CalcularPagoSemanal();
            var montoNeto = montoBruto - dto.Deducciones;

            var registro = new RegistroPago
            {
                Id = Guid.NewGuid(),
                EmpleadoId = dto.EmpleadoId,
                FechaPago = DateTime.UtcNow,
                PeriodoInicio = dto.PeriodoInicio,
                PeriodoFin = dto.PeriodoFin,
                MontoBruto = montoBruto,
                Deducciones = dto.Deducciones,
                MontoNeto = montoNeto,
                Observaciones = dto.Observaciones,
                FechaCreacion = DateTime.UtcNow
            };

            await _registroPagoRepository.AddAsync(registro);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<RegistroPagoDto>.SuccessResult(RegistroPagoUtility.MapToDto(registro))
                );
        }
    }
}
