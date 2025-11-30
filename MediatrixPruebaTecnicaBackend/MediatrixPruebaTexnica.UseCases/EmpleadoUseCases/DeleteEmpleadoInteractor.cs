using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.DeleteEmpleado;

namespace MediatrixPruebaTexnica.UseCases.EmpleadoUseCases
{
    public class DeleteEmpleadoInteractor(IEmpleadoRepository empleadoRepository, IDeleteEmpleadoOutputPort outputPort, IUnitOfWork unitOfWork) : IDeleteEmpleadoInputPort
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;
        private readonly IDeleteEmpleadoOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(Guid id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                await _outputPort.Handle(
                    Result<bool>.FailureResult("Empleado no encontrado")
                    );

                return;
            }

            _empleadoRepository.Remove(empleado);
            await _unitOfWork.SaveChangesAsync();
            await _outputPort.Handle(
                Result<bool>.SuccessResult(true)
                );
        }
    }
}
