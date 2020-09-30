using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionsImporter.DataAccess.Abstractions.Views;
using TransactionsImporter.DataAccess.EF.Metadata;

namespace TransactionsImporter.DataAccess.EF.Configurations
{
    public class TransactionViewConfiguration : IEntityTypeConfiguration<TransactionView>
    {
        public void Configure(EntityTypeBuilder<TransactionView> builder)
        {
            builder.ToView(Metadata.Views.TransactionView, Schemas.Dbo).HasNoKey();

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Amount).HasColumnName("Amount");
            builder.Property(p => p.CurrencyCode).HasColumnName("CurrencyCode");
            builder.Property(p => p.Status).HasColumnName("Status");
        }
    }
}
