using Common.Query;
using Shop.Query.Comments.DTOs;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilter : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrderByFilter(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}

