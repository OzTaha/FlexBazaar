using FlexBazaar.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Cargo.DataAccessLayer.Abstract
{
    // IGenericDal'dan CargoDetail class'ı için kalıtım/miras(inheritance) alınacak
    // *********** başka bir ifadeyle ***********
    // ICargoDetailDal interface'si, IGenericDal<CargoDetail> interface'sinden kalıtım/miras(inheritance) alır.
    // Bu, ICargoDetailDal'ın IGenericDal<CargoDetail>'de tanımlanan tüm üyeleri miras alacağı anlamına gelir.
    public interface ICargoDetailDal:IGenericDal<CargoDetail>
    {
    }
}
