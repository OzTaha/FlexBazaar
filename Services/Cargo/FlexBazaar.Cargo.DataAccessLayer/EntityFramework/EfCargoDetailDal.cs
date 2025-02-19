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
    public class EfCargoDetailDal:GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context):base(context)
        {
            
        }
    }
}
