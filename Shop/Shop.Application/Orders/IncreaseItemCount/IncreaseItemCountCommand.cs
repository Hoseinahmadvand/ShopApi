using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public record IncreaseItemCountCommand(long UserId,long ItemId,int Count):IBaseCommand;
}
