using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;

namespace MediatrixPruebaTexnica.UseCases.Utility
{
    public static class RegistroPagoUtility
    {
        public static RegistroPagoDto MapToDto(RegistroPago registroPago)
        {
            return new RegistroPagoDto
            {
                Id = registroPago.Id,
                EmpleadoId = registroPago.EmpleadoId,
                NombreEmpleado = $"{registroPago.Empleado?.PrimerNombre} {registroPago.Empleado?.ApellidoPaterno}",
                FechaPago = registroPago.FechaPago,
                PeriodoInicio = registroPago.PeriodoInicio,
                PeriodoFin = registroPago.PeriodoFin,
                MontoBruto = registroPago.MontoBruto,
                Deducciones = registroPago.Deducciones,
                MontoNeto = registroPago.MontoNeto,
                Observaciones = registroPago.Observaciones
            };
        }
    }
}
