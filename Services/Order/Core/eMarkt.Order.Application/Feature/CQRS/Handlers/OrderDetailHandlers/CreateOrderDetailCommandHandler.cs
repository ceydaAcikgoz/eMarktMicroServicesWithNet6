using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using eMarkt.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingId  = command.OrderingId,
                ProductId = command.ProductId, 
                ProductAmount = command.ProductAmount, 
                ProductName = command.ProductName, 
                ProductPrice = command.ProductPrice,   
                ProductTotalPrice = command.ProductTotalPrice
            });
        }
    }
}
