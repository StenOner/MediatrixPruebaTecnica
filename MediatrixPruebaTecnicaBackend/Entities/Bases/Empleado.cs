using MediatrixPruebaTecnica.Entities.POCOs;

namespace MediatrixPruebaTecnica.Entities.Bases
{
    public abstract class Empleado
    {
        public Guid Id { get; set; }
        public string PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string NumeroSeguroSocial { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        //public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; } = true;

        public ICollection<RegistroPago> RegistrosPagos { get; set; } = [];

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public abstract decimal CalcularPagoSemanal();
    }
}
