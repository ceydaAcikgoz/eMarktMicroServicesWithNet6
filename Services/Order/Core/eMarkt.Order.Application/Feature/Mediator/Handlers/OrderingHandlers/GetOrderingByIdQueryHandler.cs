using eMarkt.Oder.Domain.Entities;
using eMarkt.Order.Application.Feature.Mediator.Queries.OrderingQueries;
using eMarkt.Order.Application.Feature.Mediator.Results.OrderingResults;
using eMarkt.Order.Application.Interfaces;
using MediatR;

namespace eMarkt.Order.Application.Feature.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler:IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderingId = values.OrderingId,
                OrderDate = values.OrderDate,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId
            };
        }
    }
}
