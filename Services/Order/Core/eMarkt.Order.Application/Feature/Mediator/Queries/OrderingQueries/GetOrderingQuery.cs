using eMarkt.Order.Application.Feature.Mediator.Results.OrderingResults;
using MediatR;

namespace eMarkt.Order.Application.Feature.Mediator.Queries.OrderingQueries
{
    //IRequest : MediatR kütüphanesi içerisinde yer alan bir interface 
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
