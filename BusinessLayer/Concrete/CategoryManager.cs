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
    public class CategoryManager : IGenericService<Category>
    {
        ICategoryDal _categories;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categories = categoryDal;
        }
        public void TDelete(Category entity)
        {
            _categories.Delete(entity);
        }

        public List<Category> TGetAll()
        {
           return _categories.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categories.GetById(id);
        }

        public void TInsert(Category entity)
        {
            _categories.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
           _categories.Update(entity);
        }
    }
}
