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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;


        //Single responsibility prensibine dayanarak her sınıf tek bir işlem yapmalıdır.Sadece burda create işlemi yapmalıdır. 
        //Handle CQRS ve Mediator Design patternde kullanılan method ismidir.

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                Distirct = createAddressCommand.Distirct,
                UserId = createAddressCommand.UserId
            });
        }
    }
}
