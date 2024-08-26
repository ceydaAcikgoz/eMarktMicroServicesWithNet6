using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Queries.OrderDetailQueries
{
    //Parametreler tanımlandı
    public class GetOrderDetailByIdQuery
    {
        public int Id { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}

