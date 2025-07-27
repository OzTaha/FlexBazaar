using FlexBazaar.Order.Application.Interfaces;
using FlexBazaar.Order.Domain.Entities;
using FlexBazaar.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _orderContext;

        public OrderingRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public List<Ordering> GetOrderingsByUserId(string id)
        {
           var values = _orderContext.Orderings
                .Where(x => x.UserId == id)
                .ToList();
            return values;
        }
    }
}
