using FlexBazaar.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Cargo.DataAccessLayer.Abstract
{
    // ICargoOperationDal interface'si, IGenericDal<CargoOperation> interface'sinden kalıtım/miras(inheritance) alır.
    // Bu, ICargoOperationDal'ın IGenericDal<CargoOperation>'de tanımlanan tüm üyeleri miras alacağı anlamına gelir.
    public interface ICargoOperationDal:IGenericDal<CargoOperation>
    {
    }
}
