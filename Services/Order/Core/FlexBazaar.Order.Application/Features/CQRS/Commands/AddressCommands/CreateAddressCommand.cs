using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.CQRS.Commands.AddressCommands
{
    // parametleri tutacak birinci class
    public class CreateAddressCommand
    {
        public string UserId { get; set; }
        public string District { get; set; }
        // ilçe gibi (district)
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
