using System;
using System.Collections.Generic;
using System.Text;

namespace Common_DBSlide.Repositories
{
    public interface IStudentRepository<TStudent> : ICRUDRepository<TStudent,int>
    {
    }
}
