using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionsImporter.DataAccess.Abstractions.Entities;
using TransactionsImporter.DataAccess.EF.Metadata;

namespace TransactionsImporter.DataAccess.EF.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(Tables.Currency, Schemas.Dbo).HasKey(p => p.Id);
            
            builder
                .Property(p => p.Id)
                .HasColumnName("CurrencyId")
                .ValueGeneratedNever();

            builder
                .Property(p => p.Code)
                .HasColumnName("Code")
                .IsRequired();
        }
    }
}