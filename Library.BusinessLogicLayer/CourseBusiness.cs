using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class CourseBusiness : ICourseBusiness
    {
        private ICourseRepository _res;

        public CourseBusiness(ICourseRepository res)
        {
            _res = res;
        }

        public List<StudentClassCustom> GetStudentByClassID(int pageIndex, int pageSize, out long total, int course_id)
        {
            return _res.GetStudentByClassID(pageIndex, pageSize, out total, course_id);
        }
        public bool RegistedCourse(int course_id, int student_id)
        {
            return _res.RegistedCourse(course_id, student_id);
        }
        public List<CourseCustom> Search(int pageIndex, int pageSize, out long total, string course_name, int student_id)
        {
            return _res.Search(pageIndex, pageSize, out total, course_name, student_id);
        }

        public List<Course> SearchRegistedCourse(int pageIndex, int pageSize, out long total, string course_name, int student_id)
        {
            return _res.SearchRegistedCourse(pageIndex, pageSize, out total, course_name, student_id);
        }

    }
}
