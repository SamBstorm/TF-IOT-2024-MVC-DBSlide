using DAL = DAL_DBSlide.Entities;
using BLL = BLL_DBSlide.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL_DBSlide.Mappers;
using Common_DBSlide.Repositories;

namespace BLL_DBSlide.Services
{
    public class StudentService : IStudentRepository<BLL.Student>
    {
        private IStudentRepository<DAL.Student> _repository;
        public StudentService(IStudentRepository<DAL.Student> repository)
        {
            _repository = repository;
        }

        public IEnumerable<BLL.Student> Get()
        {
            return _repository.Get().Select(dal => dal.ToBLL());
        }

        public BLL.Student Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(BLL.Student entity)
        {
            return _repository.Insert(entity.ToDAL());
        }
        public void Update(int id, BLL.Student entity)
        {
            _repository.Update(id,entity.ToDAL());
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
