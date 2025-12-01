using MediatrixPruebaTecnica.Entities.Bases;

namespace MediatrixPruebaTecnica.Entities.POCOs
{
    public class EmpleadoAsalariadoPorComision : Empleado
    {
        public decimal SalarioBase { get; set; }
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }

        public override decimal CalcularPagoSemanal() =>
            (VentasBrutas * TarifaComision) + SalarioBase + (SalarioBase * 0.1m);
    }
}
