using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Queries.AddressQueries
{
    //Parametreleri tanımladık.

    public class GetAddressByIdQuery
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
