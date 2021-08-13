using DapperFluentAPI.Domain.Entities.Users;
using DapperFluentAPI.Infrastructure.Internal.Configuration;
using DapperFluentAPI.Infrastructure.Internal.Mapping;

namespace DapperFluentAPI.Infrastructure.Domain.Users
{
    public class UserConfiguration : IEntityConfiguration<User>
    {
        public IEntityTypeMapper<User> Configure(IEntityTypeMapper<User> mapper)
        {
            mapper.ToSchema(Schemas.Platform).ToTable("Users");
            mapper.Property(p => p.Id).HasColumnName("Id");
            mapper.Property(p => p.Name).HasColumnName("Name");
            mapper.Property(p => p.Surname).HasColumnName("Surname");
            mapper.Property(p => p.Email).HasColumnName("Email");
            mapper.Property(p => p.CreationDate).HasColumnName("CreationDate");
            mapper.Property(p => p.LastModificationDate).HasColumnName("LastModificationDate");

            return mapper;
        }
    }
}