using FlexBazaar.Cargo.DataAccessLayer.Abstract;
using FlexBazaar.Cargo.DataAccessLayer.Concrete;
using FlexBazaar.Cargo.DataAccessLayer.Repositories;
using FlexBazaar.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Cargo.DataAccessLayer.EntityFramework
{
    // GenericRepository'den miras alınacak. CargoCompany class'na özgü metodlar gelirse ICargoCompanyDal interface'sinden miras(inheritance) alacak.
    public class EfCargoCustomerDal:GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        // : base(context) ifadesi, miras alınan class'ın (GenericRepository<CargoCompany>) constructor'ını çağırarak, base class'ın doğru şekilde başlatılmasını sağlar.
        public EfCargoCustomerDal(CargoContext context): base(context)
        {
            
        }
    }
}
