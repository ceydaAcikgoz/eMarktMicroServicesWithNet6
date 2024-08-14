using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Feature.CQRS.Results.AddressResults
{
    //Propertyleri tutar ve listeler
    public class GetAddressQueryResult
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string Distirct { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
