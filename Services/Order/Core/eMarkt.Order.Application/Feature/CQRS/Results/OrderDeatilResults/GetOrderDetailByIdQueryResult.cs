using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Results.OrderDeatilResults
{
    public class GetOrderDetailByIdQueryResult
    {
        public int Id { get; set; }
        public int OderDetailId { get; set; }
        public int OrderingId { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int ProductAmount { get; set; }

        public decimal ProductPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
    }
}
