using DAL = DAL_DBSlide.Entities;
using BLL_DBSlide.Entities;
using Common_DBSlide.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL_DBSlide.Mappers;

namespace BLL_DBSlide.Services
{
    public class SectionService : ISectionRepository<Section>
    {
        private ISectionRepository<DAL.Section> _repository;

        public SectionService(ISectionRepository<DAL.Section> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Section> Get()
        {
            return _repository.Get().Select(dal => dal.ToBLL());
        }

        public Section Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Section entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, Section entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
