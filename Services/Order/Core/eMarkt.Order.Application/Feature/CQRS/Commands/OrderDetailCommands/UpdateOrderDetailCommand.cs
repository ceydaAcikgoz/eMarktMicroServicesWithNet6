using eMarkt.Oder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand
    {
        public int OderDetailId { get; set; }
        public int OrderingId { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
    }
}
