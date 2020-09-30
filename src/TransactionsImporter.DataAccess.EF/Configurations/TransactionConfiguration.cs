using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionsImporter.DataAccess.Abstractions.Entities;
using TransactionsImporter.DataAccess.EF.Metadata;

namespace TransactionsImporter.DataAccess.EF.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable(Tables.Transaction, Schemas.Dbo).HasKey(p => p.Id);

            builder
                .Property(p => p.Amount)
                .HasColumnName("Amount")
                .HasColumnType("float")
                .IsRequired();

            builder.OwnsOne(p => p.TransactionId, x =>
            {
                x.Property(p => p.Value)
                    .HasColumnName("TransactionId")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();
            });

            builder.OwnsOne(p => p.TransactionDate, x =>
            {
                x.Property(p => p.Value)
                    .HasColumnName("TransactionDate")
                    .IsRequired();
            });

            builder
                .HasOne(p => p.Currency)
                .WithMany()
                .IsRequired();
        }
    }
}
