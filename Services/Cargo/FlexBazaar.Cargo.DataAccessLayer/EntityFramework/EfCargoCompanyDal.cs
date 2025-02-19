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
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        /*
         : base(context) ifadesi, miras alınan class'ın (GenericRepository<CargoCompany>) constructor'ını çağırarak, base class'ın(GenericRepository<CargoCompany>) doğru şekilde başlatılmasını sağlar. Bu, OOP'de sıkça kullanılan bir tekniktir ve kodun daha modüler ve tekrar kullanılabilir olmasını sağlar.
        Ayrıca bu class, generic bir class'tır. Yani, T tip parametresi alır ve bu parametre, class'ın hangi varlık (entity) tipi üzerinde çalışacağını belirler.
         */
        public EfCargoCompanyDal(CargoContext context): base(context)
        {
            
        }
    }
}
