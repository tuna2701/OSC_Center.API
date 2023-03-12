using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface ICourseBusiness
    {
        bool RegistedCourse(int course_id, int student_id);
        List<StudentClassCustom> GetStudentByClassID(int pageIndex, int pageSize, out long total, int course_id);
        List<CourseCustom> Search(int pageIndex, int pageSize, out long total, string course_name, int student_id);
        List<Course> SearchRegistedCourse(int pageIndex, int pageSize, out long total, string course_name, int student_id);
    }
}
