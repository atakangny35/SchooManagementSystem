using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Entity.EntityFramework.Context.Mapper
{
    public class UserMapper: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
