using DapperFluentAPI.Domain.Entities.Orders;
using DapperFluentAPI.Infrastructure.Internal.Configuration;
using DapperFluentAPI.Infrastructure.Internal.Mapping;

namespace DapperFluentAPI.Infrastructure.Domain.Orders
{
    public class OrderConfiguration : IEntityConfiguration<Order>
    {
        public IEntityTypeMapper<Order> Configure(IEntityTypeMapper<Order> mapper)
        {
            mapper.ToSchema(Schemas.Platform).ToTable("Orders");

            mapper.Property(p => p.Id).HasColumnName("Id");
            mapper.Property(p => p.ProductName).HasColumnName("ProductName");
            mapper.Property(p => p.Price).HasColumnName("Price");

            return mapper;
        }
    }
}
