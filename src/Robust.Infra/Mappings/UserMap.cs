using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Robust.Domain.Entities;

namespace Robust.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name");


            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("password");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("email");
        }
    }
}
