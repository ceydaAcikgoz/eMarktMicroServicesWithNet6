using eMarkt.Order.Application.Feature.Mediator.Results.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery:IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int id) {

            Id = id;
        }
    }
}
