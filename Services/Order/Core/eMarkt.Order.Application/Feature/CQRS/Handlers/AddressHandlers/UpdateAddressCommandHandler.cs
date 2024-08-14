using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.CQRS.Commands.AddressCommands;
using eMarkt.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);  
            values.Detail = command.Detail;
            values.Distirct = command.Distirct;
            values.City = command.City;
            values.UserId = command.UserId; 

            await _repository.UpdateAsync(values);  
        }
    }
}
