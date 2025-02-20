using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        // başında T olanlar business katmanından gelenler olacak
        // DataAccessLayer katmanıyla karışmaması için
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
        T TGetById(int id);
        List<T> TGetAll();
    }
}
