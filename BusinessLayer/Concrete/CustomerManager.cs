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
    public class CustomerManager : IGenericService<Customer>
    {
        ICustomerDal _customers;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customers = customerDal;
        }

        public List<Customer> GetCustomersListWithJob()
        {
            return _customers.GetCustomerListWithJob();
        }

        public void TDelete(Customer entity)
        {
            _customers.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customers.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customers.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            _customers.Insert(entity);
        }

        public void TUpdate(Customer entity)
        {
            _customers.Update(entity);
        }
    }
}
