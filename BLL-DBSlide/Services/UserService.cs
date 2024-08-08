using BLL_DBSlide.Entities;
using DAL = DAL_DBSlide.Entities;
using Common_DBSlide.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using BLL_DBSlide.Mappers;
using BLL_DBSlide.Entities.Enums;
using System.Linq;

namespace BLL_DBSlide.Services
{
    public class UserService : IUserRepository<User,Role>
    {
        private readonly IUserRepository<DAL.User, string> _userRepository;
        public UserService(IUserRepository<DAL.User, string> userRepository)
        {
            _userRepository = userRepository;
        }
        public Guid? CheckPassword(string email, string password)
        {
            return _userRepository.CheckPassword(email, password);
        }

        public void ClearRole(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            return _userRepository.Get(id).ToBLL();
        }

        public IEnumerable<Role> GetRoles(Guid id)
        {
            return _userRepository.GetRoles(id).Select(s => Enum.Parse<Role>(s));
        }

        public Guid Insert(User user)
        {
            return _userRepository.Insert(user.ToDAL());
        }

        public void SetAdmin(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SetAutor(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SetModerator(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
