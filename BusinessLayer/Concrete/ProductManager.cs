using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager: IGenericService<Product>
    {
        IProductDal _productdal;
        public ProductManager(IProductDal productDal)
        {
            _productdal = productDal;
        }

        public void TDelete(Product entity)
        {
            _productdal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productdal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productdal.GetById(id);
        }

        public void TInsert(Product entity)
        {
            _productdal.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productdal.Update(entity);
        }
    }
}
