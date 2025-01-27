using FlexBazaar.Order.Application.Features.Mediator.Commands.OrderingCommands;
using FlexBazaar.Order.Application.Interfaces;
using FlexBazaar.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAysnc(request.OrderingId);
            values.UserId = request.UserId;
            values.TotalPrice = request.TotalPrice;
            values.OrderDate = request.OrderDate;
            await _repository.UpdateAsync(values);
        }
    }
}
