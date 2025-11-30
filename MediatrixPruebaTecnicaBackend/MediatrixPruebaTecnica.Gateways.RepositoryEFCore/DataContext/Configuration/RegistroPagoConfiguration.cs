using MediatrixPruebaTecnica.Entities.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext.Configuration
{
    public class RegistroPagoConfiguration : IEntityTypeConfiguration<RegistroPago>
    {
        public void Configure(EntityTypeBuilder<RegistroPago> builder)
        {
            builder.ToTable("RegistrosPagos");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.MontoBruto)
                .HasPrecision(10, 2);

            builder.Property(r => r.Deducciones)
                .HasPrecision(10, 2);

            builder.Property(r => r.MontoNeto)
                .HasPrecision(10, 2);

            builder.HasIndex(r => new { r.EmpleadoId, r.FechaPago });
        }
    }
}
