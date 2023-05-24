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
    public class JobManager : IGenericService<Job>
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }
        public void TDelete(Job entity)
        {
            _jobDal.Delete(entity);
        }

        public List<Job> TGetAll()
        {
            return _jobDal.GetAll();
        }

        public Job TGetById(int id)
        {
           return _jobDal.GetById(id);
        }

        public void TInsert(Job entity)
        {
            _jobDal.Insert(entity);
        }

        public void TUpdate(Job entity)
        {
            _jobDal.Update(entity);
        }
    }
}
