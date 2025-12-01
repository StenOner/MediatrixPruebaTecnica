using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.UpdateRegistroPago;

namespace MediatrixPruebaTexnica.UseCases.RegistroPagoUseCases
{
    public class UpdateRegistroPagoInteractor(IRegistroPagoRepository registroPagoRepository, IEmpleadoRepository empleadoRepository, IUpdateRegistroPagoOutputPort outputPort, IUnitOfWork unitOfWork)
        : IUpdateRegistroPagoInputPort
    {
        private readonly IRegistroPagoRepository _registroPagoRepository = registroPagoRepository;
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IUpdateRegistroPagoOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(Guid id, UpdateRegistroPagoDto dto)
        {
            var registro = await _registroPagoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                await _outputPort.Handle(
                    Result<RegistroPagoDto>.FailureResult("Registro no encontrado")
                    );

                return;
            }

            var empleado = await _empleadoRepository.GetByIdAsync(registro.EmpleadoId);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<RegistroPagoDto>.FailureResult("Registro corrupto")
                    );

                return;
            }

            registro.MontoBruto = empleado.CalcularPagoSemanal();
            registro.Deducciones = dto.Deducciones;
            registro.MontoNeto = registro.MontoBruto - registro.Deducciones;
            registro.Observaciones = dto.Observaciones;

            _registroPagoRepository.Update(registro);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<RegistroPagoDto>.SuccessResult(RegistroPagoUtility.MapToDto(registro))
                );
        }
    }
}
