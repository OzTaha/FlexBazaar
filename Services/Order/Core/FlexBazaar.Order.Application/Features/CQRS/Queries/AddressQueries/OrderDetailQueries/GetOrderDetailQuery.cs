using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.CQRS.Queries.AddressQueries.OrderDetailQueries
{
    public class GetOrderDetailQuery
    {
        public int Id { get; set; }

        public GetOrderDetailQuery(int id)
        {
            Id = id;
        }
    }
}
