using System;
using System.Collections.Generic;
using System.Text;

namespace Common_DBSlide.Repositories
{
    public interface IUserRepository<TUser,TRole>
    {
        Guid Insert(TUser user);
        Guid? CheckPassword(string email, string password);
        TUser Get(Guid id);
        IEnumerable<TRole> GetRoles(Guid id);

        void SetAdmin(Guid id);
        void SetAutor(Guid id);
        void SetModerator(Guid id);
        void ClearRole(Guid id);
    }
}
