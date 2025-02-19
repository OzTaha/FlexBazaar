using FlexBazaar.Cargo.DataAccessLayer.Abstract;
using FlexBazaar.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Cargo.DataAccessLayer.Repositories
{
    // GenericRepository<T> calss'ı, IGenericDal<T> interface'sini uygular (implement eder).
    /*
     GenericRepository<T>:

    Bu class, generic bir class'tır. Yani, T adında bir tip parametresi alır.

    T, bu class'ın çalışacağı varlık (entity) tipini temsil eder. Örneğin, CargoDetail, Product, User gibi herhangi bir class olabilir.

    Bu sayede, GenericRepository class'ı, farklı entityler için tekrar kullanılabilir hale gelir.
     */
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            var values = _context.Set<T>().ToList();
            return values;
        }

        public T GetById(int id)
        {
            var value = _context.Set<T>().Find(id);
            return value;
        }

        public void Insert(T entity)
        {
           _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
