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
    public class EfCargoOperationDal:GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context):base(context)
        {
            
        }
    }
}
