using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionHistory.Domain.Entities;

namespace TransactionHistory.Infra.Persistence.Mappings
{
    public sealed class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
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
                .HasOne(x => x.Person)
                .WithOne(x => x.Account)
                .HasForeignKey<Account>(x => x.PersonId);


        }
    }
}
