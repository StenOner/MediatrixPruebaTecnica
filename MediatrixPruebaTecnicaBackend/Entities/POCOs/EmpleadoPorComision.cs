using MediatrixPruebaTecnica.Entities.Bases;

namespace MediatrixPruebaTecnica.Entities.POCOs
{
    public class EmpleadoPorComision : Empleado
    {
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }

        public override decimal CalcularPagoSemanal() => VentasBrutas * TarifaComision;
    }
}
