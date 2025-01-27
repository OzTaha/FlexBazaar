using FlexBazaar.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    // her bir entitity için bir query oluşturulur. 
    // tüm liste dönecek.
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
