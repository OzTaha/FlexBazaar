using FlexBazaar.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Cargo.DataAccessLayer.Abstract
{
    // IGenericDal'dan CargoCompany class'ı için kalıtım/miras(inheritance) alınacak
    public interface ICargoCompanyDal: IGenericDal<CargoCompany>
    {
    }
}
