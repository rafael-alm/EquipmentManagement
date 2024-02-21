using equipmentManagement.infra.data.input.entityTypeConfiguration.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace equipmentManagement.infra.data.input.entityTypeConfiguration
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<CompanyModel>
    {
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id)
                   .HasColumnType("CHAR")
                   .HasMaxLength(32);

            builder.Property(x => x.RegisteredName)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(250);

            builder.Property(x => x.Name)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(250);

            builder.Property(x => x.CNPJ)
               .HasColumnType("VARCHAR")
               .HasMaxLength(14);
        }
    }
}