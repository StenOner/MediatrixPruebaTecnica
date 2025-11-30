using MediatrixPruebaTecnica.Entities.Bases;
using MediatrixPruebaTecnica.Entities.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleados");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.PrimerNombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ApellidoPaterno)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.NumeroSeguroSocial)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Departamento)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(e => e.NumeroSeguroSocial)
                .IsUnique();

            builder.HasIndex(e => e.Departamento);

            builder.HasDiscriminator<string>("TipoEmpleado")
                .HasValue<EmpleadoAsalariado>("Asalariado")
                .HasValue<EmpleadoPorHoras>("PorHoras")
                .HasValue<EmpleadoPorComision>("PorComision")
                .HasValue<EmpleadoAsalariadoPorComision>("AsalariadoPorComision");

            builder.HasMany(e => e.RegistrosPagos)
                .WithOne(r => r.Empleado)
                .HasForeignKey(r => r.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
