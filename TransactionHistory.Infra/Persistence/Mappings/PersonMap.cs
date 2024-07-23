using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionHistory.Domain.Entities;

namespace TransactionHistory.Infra.Persistence.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Name");

            //builder.HasOne(x => x.Account)
            //    .WithOne(x => x.Person);
            //.HasForeignKey();
        }
    }
}
