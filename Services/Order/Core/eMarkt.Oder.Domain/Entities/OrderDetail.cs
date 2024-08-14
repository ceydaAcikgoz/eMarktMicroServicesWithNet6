using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Oder.Domain.Entities
{
    public class OrderDetail
    {
        public int OderDetailId { get; set; }
        public int OrderingId { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public Ordering Ordering { get; set; }
    }
}
