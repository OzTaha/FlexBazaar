using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.CQRS.Results.AddressResults
{
    // Address'i id'ye göre getirecek olan class
    // burada listelemeye ihtiyaç duyarız.
    public class GetAddressByIdQueryResult
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        // ilçe gibi (district)
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
