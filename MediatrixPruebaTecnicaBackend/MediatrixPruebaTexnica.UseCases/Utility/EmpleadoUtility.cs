using MediatrixPruebaTecnica.Entities.Bases;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCases.Utility
{
    public static class EmpleadoUtility
    {
        public static EmpleadoDto MapToDto(Empleado empleado)
        {
            var tipoEmpleado = empleado switch
            {
                EmpleadoAsalariado => "Asalariado",
                EmpleadoPorHoras => "PorHoras",
                EmpleadoPorComision => "PorComision",
                EmpleadoAsalariadoPorComision => "AsalariadoPorComision",
                _ => "Desconocido"
            };

            return new EmpleadoDto
            {
                Id = empleado.Id,
                PrimerNombre = empleado.PrimerNombre,
                ApellidoPaterno = empleado.ApellidoPaterno,
                NumeroSeguroSocial = empleado.NumeroSeguroSocial,
                Departamento = empleado.Departamento,
                Activo = empleado.Activo,
                TipoEmpleado = tipoEmpleado,
                PagoSemanal = empleado.CalcularPagoSemanal()
            };
        }
    }
}
