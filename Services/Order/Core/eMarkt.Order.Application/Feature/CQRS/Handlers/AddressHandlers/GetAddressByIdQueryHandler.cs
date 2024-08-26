using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.CQRS.Queries.AddressQueries;
using eMarkt.Order.Application.Feature.CQRS.Results.AddressResults;
using eMarkt.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                Distirct = values.Distirct,
                UserId = values.UserId
            };
        }
    }
}
