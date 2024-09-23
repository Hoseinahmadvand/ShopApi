using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.Mapper
{
    public static class OrderMapper
    {
        public static OrderDto Map(this Order dto)
        {
            if (dto == null)
                return null;
            return new OrderDto()
            {
                Id = dto.Id,
                CreationDate = dto.CreationDate,
                Status = dto.Status,
                Discount = dto.Discount,
                Address = dto.Address,
                Items = new(),
                LastUpdate = dto.LastUpdate,
                ShippingMethod = dto.ShippingMethod,
                UserId = dto.UserId,
                FullName = "",

            };
        }

        public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto dto, DapperContext dapperContext)
        {
          
            using var connection=dapperContext.CreateConnection();
            var sqlScript = @$"SELECT s.ShopName,o.OrderId,o.InventoryId,o.Count,o.Price,
                              p.Title as [Product.Title],p.Slug as [Product.Slug], p.ImageName as[Product.ImageName]
                              FROM {dapperContext.OrderItems}
                              Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id
                              Inner Join {dapperContext.Products} p on i.ProductId=p.Id 
                              Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id
                              where o.OrderId=@orderId ";
            var result=await connection.QueryAsync<OrderItemDto>(sqlScript, new {orderId=dto.Id});
            return result.ToList();
        }
        public static OrderFilterData MapFilterData(this Order dto, ShopContext context)
        {
            var fullName = context.Users
                .Where(u => u.Id == dto.UserId)
                .Select(u => $"{u.Name} {u.Family}")
                .First();
            return new OrderFilterData()
            {
                Id = dto.Id,
                Status = dto.Status,
                City = dto.Address?.City,
                Shire = dto.Address?.Shire,
                ShippingType = dto.ShippingMethod?.ShippingType,
                CreationDate = dto.CreationDate,
                TotalItemCount = dto.ItemCount,
                TotalPrice = dto.TotalPrice,
                UserId = dto.UserId,
                UserFullName = fullName

            };
        }
    }
}
