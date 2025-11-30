using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.DeleteRegistroPago;

namespace MediatrixPruebaTexnica.UseCases.RegistroPagoUseCases
{
    public class DeleteRegistroPagoInteractor(IRegistroPagoRepository registroPagoRepository, IDeleteRegistroPagoOutputPort outputPort, IUnitOfWork unitOfWork) : IDeleteRegistroPagoInputPort
    {
        private readonly IRegistroPagoRepository _registroPagoRepository = registroPagoRepository;
        private readonly IDeleteRegistroPagoOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(Guid id)
        {
            var registro = await _registroPagoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                await _outputPort.Handle(
                    Result<bool>.FailureResult("Registro no encontrado")
                    );

                return;
            }

            _registroPagoRepository.Remove(registro);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<bool>.SuccessResult(true)
                );
        }
    }
}
