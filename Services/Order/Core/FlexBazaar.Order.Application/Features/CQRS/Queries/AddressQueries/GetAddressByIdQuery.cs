using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public int Id { get; set; }
        // controllerde constructor üzerinden çağırmamız gerek.
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
