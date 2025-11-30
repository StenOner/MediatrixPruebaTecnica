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
        }
    }
}
