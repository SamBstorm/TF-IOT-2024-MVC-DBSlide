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

        public static StudentDetailsViewModel ToDetails(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentDetailsViewModel()
            {
                Student_Id = entity.Student_id,
                First_Name = entity.First_name,
                Last_Name = entity.Last_name,
                Login = entity.Login,
                Birth_Date = entity.Birth_date,
                Section_Id = entity.Section_id,
                Year_Result = entity.Year_result,
                Course_Id = entity.Course_id
            };
        }
        public static StudentDeleteForm ToDelete(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentDeleteForm()
            {
                First_Name = entity.First_name,
                Last_Name = entity.Last_name,
                Section_Id = entity.Section_id
            };
        }
        public static StudentEditForm ToEdit(this Student entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new StudentEditForm()
            {
                Section_Id = entity.Section_id,
                Year_Result = entity.Year_result,
                Course_Id = entity.Course_id
            };
        }

        public static Student ToBLL(this StudentCreateForm entity) {
            if(entity is null) throw new ArgumentNullException(nameof(entity));
            return new Student()
            {
                First_name = entity.First_Name,
                Last_name = entity.Last_Name,
                Birth_date = entity.Birth_Date,
                Section_id = entity.Section_id,
                Course_id = "0"
            };
        }
        public static Student ToBLL(this StudentEditForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Student()
            {
                Course_id = entity.Course_Id,
                Section_id = entity.Section_Id,
                Year_result = entity.Year_Result
            };
        }
        #endregion
    }
}
