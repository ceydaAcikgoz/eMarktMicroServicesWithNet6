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
    public class RemoveOrderDetailCommandHandler
    {

        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
