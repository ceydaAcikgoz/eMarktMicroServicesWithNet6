using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.CQRS.Commands.AddressCommands;
using eMarkt.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using eMarkt.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {

        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OderDetailId);
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProductId = command.ProductId;
            values.OrderingId = command.OrderingId;
            values.ProductAmount = command.ProductAmount;

            await _repository.UpdateAsync(values);

        }
    }
}

