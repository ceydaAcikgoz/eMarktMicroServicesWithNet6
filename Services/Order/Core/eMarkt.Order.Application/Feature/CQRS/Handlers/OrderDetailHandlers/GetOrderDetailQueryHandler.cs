using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.CQRS.Results.AddressResults;
using eMarkt.Order.Application.Feature.CQRS.Results.OrderDeatilResults;
using eMarkt.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OderDetailId = x.OderDetailId,
                ProductTotalPrice = x.ProductTotalPrice,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductId = x.ProductId,
                ProductAmount = x.ProductAmount,
                OrderingId = x.OrderingId

            }).ToList();
        }
    }
}
