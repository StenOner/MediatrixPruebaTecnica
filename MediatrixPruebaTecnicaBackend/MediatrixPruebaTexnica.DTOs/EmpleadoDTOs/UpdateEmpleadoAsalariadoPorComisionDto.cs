using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrixPruebaTexnica.DTOs.EmpleadoDTOs
{
    public class UpdateEmpleadoAsalariadoPorComisionDto
    {
        public string PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal SalarioBase { get; set; }
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }
        public bool Activo { get; set; }
    }
}
