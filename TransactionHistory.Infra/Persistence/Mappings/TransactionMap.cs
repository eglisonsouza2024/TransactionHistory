using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionHistory.Domain.Entities;

namespace TransactionHistory.Infra.Persistence.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("Datetime");

            builder
                .Property(x => x.UpdatedAt)
                .HasColumnType("Datetime");

            builder
                .Property(x => x.TransactionDate)
                .IsRequired()
                .HasColumnName("TransactionDate")
                .HasColumnType("Datetime");

            builder
                .Property(x => x.TransactionType)
                .IsRequired()
                .HasColumnName("TransactionType")
                .HasColumnType("int");

            builder
                .Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("Amount")
                .HasColumnType("decimal(20,2)");

            builder
                .HasOne(x => x.Account)
                .WithMany(x => x.Transactions);
        }
    }
}
