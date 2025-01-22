using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.CQRS.Results.AddressResults
{
    // address class'ındaki property'leri tutacak ve bunların listelenmesini sağlayacak. 
    // Address class'ı domain katmanıda
    public class GetAddressQueryResult
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        // ilçe gibi (district)
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
