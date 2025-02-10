using FlexBazaar.Order.Application.Features.CQRS.Queries.AddressQueries;
using FlexBazaar.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using FlexBazaar.Order.Application.Features.CQRS.Results.AddressResults;
using FlexBazaar.Order.Application.Features.CQRS.Results.OrderDetailResults;
using FlexBazaar.Order.Application.Interfaces;
using FlexBazaar.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAysnc(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
               OrderDetailId = values.OrderDetailId,
                ProductId = values.ProductId,
                ProductAmount = values.ProductAmount,
                ProductName = values.ProductName,
                OrderingId = values.OrderingId,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}
