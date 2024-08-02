using ASP_DBSlide.Models.Student;
using BLL_DBSlide.Entities;

namespace ASP_DBSlide.Mapper
{
    public static class Mapper
    {
        #region Student
        public static StudentListItem ToListItem(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentListItem()
            {
                Student_Id = entity.Student_id,
                First_Name = entity.First_name,
                Last_Name = entity.Last_name
            };
        } 
        #endregion
    }
}
