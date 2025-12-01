using MediatrixPruebaTecnica.Entities.Bases;

namespace MediatrixPruebaTecnica.Entities.POCOs
{
    public class EmpleadoPorHoras : Empleado
    {
        public decimal SueldoPorHora { get; set; }
        public decimal HorasTrabajadas { get; set; }

        public override decimal CalcularPagoSemanal()
        {
            if (HorasTrabajadas <= 40)
                return SueldoPorHora * HorasTrabajadas;

            return (SueldoPorHora * 40) + (SueldoPorHora * 1.5m * (HorasTrabajadas - 40));
        }
    }
}
