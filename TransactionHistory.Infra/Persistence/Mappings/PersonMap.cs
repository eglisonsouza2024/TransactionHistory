using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TransactionHistory.Domain.Entities;

namespace TransactionHistory.Infra.Persistence.Mappings
{
    [ExcludeFromCodeCoverage]
    public sealed class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("Datetime");

            builder
                .Property(x => x.UpdatedAt)
                .HasColumnType("Datetime");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(x => x.Account)
                .WithOne(x => x.Person)
                .HasForeignKey<Account>(x => x.PersonId);
        }
    }
}
