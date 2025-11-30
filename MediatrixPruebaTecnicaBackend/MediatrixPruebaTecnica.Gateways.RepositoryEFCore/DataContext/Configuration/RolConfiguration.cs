using MediatrixPruebaTecnica.Entities.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(r => r.Nombre)
                .IsUnique();

            // Seed data
            //builder.HasData(
            //    new Rol
            //    {
            //        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            //        Nombre = "Admin",
            //        Descripcion = "Administrador",
            //        FechaCreacion = DateTime.UtcNow
            //    },
            //    new Rol
            //    {
            //        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            //        Nombre = "User",
            //        Descripcion = "Usuario",
            //        FechaCreacion = DateTime.UtcNow
            //    }
            //);
        }
    }
}
