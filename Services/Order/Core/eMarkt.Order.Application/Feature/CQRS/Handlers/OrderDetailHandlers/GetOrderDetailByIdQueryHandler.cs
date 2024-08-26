using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.CQRS.Queries.OrderDetailQueries;
using eMarkt.Order.Application.Feature.CQRS.Results.OrderDeatilResults;
using eMarkt.Order.Application.Interfaces;


namespace eMarkt.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers
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
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OderDetailId = values.OderDetailId,
                OrderingId = values.OrderingId,
                ProductAmount = values.ProductAmount,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}
